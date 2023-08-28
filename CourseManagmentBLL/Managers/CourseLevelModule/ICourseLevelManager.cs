using CourseManagmentBLL.DTO.CourseLevelDto;

namespace CourseManagmentBLL.Managers.CourseLevelModule
{
    public interface ICourseLevelManager
    {
        Task<List<CourseLevelGetAllDto>> GetAll();
    }
}
