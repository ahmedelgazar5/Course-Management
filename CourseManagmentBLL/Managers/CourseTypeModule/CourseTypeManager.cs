using CourseManagmentBLL.DTO.CourseTypeDto;
using CourseManagmentDAL;
using Microsoft.EntityFrameworkCore;

namespace CourseManagmentBLL.Managers.CourseTypeModule
{
    public class CourseTypeManager:ICourseTypeManager
    {
        private CourseContext _context;
        public CourseTypeManager(CourseContext context)
        {
            _context = context;
        }

        public Task<List<CourseTypeGetAllDto>> GetAll()
        {
            return _context.CourseTypes
                .Where(c => c.IsDeleted == false)
                .Select(c => new CourseTypeGetAllDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }
    }
}
