using CourseManagmentBLL.DTO.CourseTypeDto;

namespace CourseManagmentBLL.Managers.CourseTypeModule
{
    public interface ICourseTypeManager
    {
        Task<List<CourseTypeGetAllDto>> GetAll();
    }
}
