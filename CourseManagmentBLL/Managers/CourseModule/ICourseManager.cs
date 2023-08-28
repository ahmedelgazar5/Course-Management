using CourseManagmentBLL.DTO.CourseDTO;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagmentBLL.Managers.CourseModule
{
    public interface ICourseManager
    {
        Task<CoursesDto> GetAll(CoursesQueryDto query);
        Task<CourseAddedDto> Create(CourseCreateDto courseDto);
        Task<CourseDetailsDto> GetById(int id);
        Task<int> Update(CourseUpdateDto courseUpdate, int id);
        Task<int> Delete(int id);
    }
}
