using CourseManagmentBLL.DTO.SessionDto;
using CourseManagmentBLL.DTO.SessionsDto;

namespace CourseManagmentBLL.Managers.SessionsModule
{
    public interface ISessionsManager
    {
        Task<List<SessionGetAllDto>> GetAll();
        Task<SessionCreateDto> Create(SessionCreateDto sessionCreateDto);
        Task<int> Update(SessionUpdateDto sessionUpdateDto);

    }
}
