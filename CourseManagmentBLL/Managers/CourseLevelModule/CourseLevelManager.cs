using CourseManagmentBLL.DTO.CourseLevelDto;
using CourseManagmentDAL;
using Microsoft.EntityFrameworkCore;

namespace CourseManagmentBLL.Managers.CourseLevelModule
{
    public class CourseLevelManager:ICourseLevelManager
    {
        private CourseContext _context;
        public CourseLevelManager(CourseContext context)
        {
            _context = context;
        }

        public Task<List<CourseLevelGetAllDto>> GetAll()
        {
            return _context.CourseLevels
                .Where(c => c.IsDeleted == false)
                .Select(c => new CourseLevelGetAllDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }
    }
}
