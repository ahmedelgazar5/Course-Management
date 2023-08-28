using CourseManagmentBLL.DTO.CourseDTO;
using CourseManagmentBLL.DTO.LookUpDTO;
using CourseManagmentBLL.DTO.SessionsDto;
using CourseManagmentDAL;

using CourseManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagmentBLL.Managers.CourseModule
{
    public class CourseManager : ICourseManager
    {

        private CourseContext _context;
        public CourseManager(CourseContext context)
        {
            _context = context;
        }

        public async Task<CoursesDto> GetAll(CoursesQueryDto query)
        {
            var dbQuery = _context.Courses
                   .Where(c => query.Name == null || c.Name.Contains(query.Name))
                   .Where(c => query.CourseTypeId == null || c.CourseTypeId == query.CourseTypeId)
                   .Where(c => c.IsDeleted == false)
                   .Where(c => query.Price == null || c.Price == query.Price);
            var totalCount = dbQuery.Count();
            var result = new CoursesDto();
            result.TotalCount = totalCount;
            result.Courses = await dbQuery
                            .Include(c => c.CourseType)
                            .Include(c => c.CourseLevel)
                            .Include(c=>c.Session)
                            .Skip(query.PageSize * query.PageIndex)
                            .Take(query.PageSize)
                            .Select(c => new CourseGetAllDto
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Description = c.Description,
                                CourseType = c.CourseType.Name,
                                Price = c.Price,
                                CourseLevel = c.CourseLevel.Name,
                                Sessions=c.Session.Select(s => new SessionsWithoutIdDto
                                {
                                    SessionName=s.Name,
                                    DurationInMins=s.DurationInMins
                                }).ToList()
                            }).ToListAsync();
            return result;

        }

        public async Task<CourseAddedDto> Create(CourseCreateDto courseCreateDto)
        {

            if (courseCreateDto == null) throw new ArgumentException(nameof(courseCreateDto));
            if (courseCreateDto.Price < 100) throw new Exception("Invalid Price!!!");


            var courseDb = new Course()
            {
                Name = courseCreateDto.Name,
                Description = courseCreateDto.Description,
                CourseTypeId = courseCreateDto.CourseTypeId,
                Price = courseCreateDto.Price,
                CourseLevelId = courseCreateDto.CourseLevelId,
                Session = courseCreateDto.Sessions.Select(s => new Session
                {
                    Name = s.SessionName,
                    DurationInMins = s.DurationInMins
                }).ToList()

            };

            await _context.Courses.AddAsync(courseDb);

            await _context.SaveChangesAsync();

            var result = new CourseAddedDto()
            {
                Id = courseDb.Id,
                Name = courseDb.Name

            };
            return result;
        }

        public async Task<CourseDetailsDto> GetById(int id)
        {
            var course = await _context.Courses
                        .Include(c => c.CourseType)
                        .Include(c => c.CourseLevel)
                        //.Include(c => c.Session)
                        .Where(c => c.IsDeleted == false).FirstOrDefaultAsync(c => c.Id == id);
            var courseDto = new CourseDetailsDto
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                CourseType = new LookUpDto
                {
                    Id = course.CourseType.Id,
                    Name = course.CourseType.Name
                },
                Price = course.Price,
                CourseLevel = new LookUpDto
                {
                    Id = course.CourseLevel.Id,
                    Name = course.CourseLevel.Name
                },
                //Sessions = course.Session.Select(s => new SessionsWithoutIdDto
                //{
                //    SessionName=s.Name,
                //    DurationInMins=s.DurationInMins
                //}).ToList()
            };
            return courseDto;
        }

        public async Task<int> Update(CourseUpdateDto courseUpdate, int id)
        {
            if (courseUpdate == null)
                throw new ArgumentException(nameof(courseUpdate));

            var courseDb = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (courseDb == null) throw new ArgumentException(nameof(courseDb));

            courseDb.Name = courseUpdate.Name;
            courseDb.Description = courseUpdate.Description;
            courseDb.CourseTypeId = courseUpdate.CourseTypeId;
            courseDb.Price = courseUpdate.Price;
            courseDb.CourseLevelId = courseUpdate.CourseLevelId;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var courseDb = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (courseDb == null) throw new ArgumentException(nameof(courseDb));
            courseDb.IsDeleted = true;
            return await _context.SaveChangesAsync();
        }

    }
}
