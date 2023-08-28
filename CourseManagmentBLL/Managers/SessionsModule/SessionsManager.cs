using CourseManagmentBLL.DTO.CourseDTO;
using CourseManagmentBLL.DTO.SessionDto;
using CourseManagmentBLL.DTO.SessionsDto;
using CourseManagmentDAL;
using CourseManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagmentBLL.Managers.SessionsModule
{
    public class SessionsManager : ISessionsManager
    {
        private CourseContext _context;
        public SessionsManager(CourseContext context)
        {
            _context = context;
        }

        public Task<List<SessionGetAllDto>> GetAll()
        {
            return _context.Sessions
                .Where(s => s.IsDeleted == false)
                .Select(s => new SessionGetAllDto
                {
                    Name = s.Name,
                    DurationInMins = s.DurationInMins,
                    CourseId = s.CourseId
                }).ToListAsync();
        }
        public async Task<SessionCreateDto> Create(SessionCreateDto sessionCreateDto)
        {

            if (sessionCreateDto == null) throw new ArgumentException(nameof(sessionCreateDto));

            var sessionDb = new Session()
            {
                Name = sessionCreateDto.SessionName,
                DurationInMins = sessionCreateDto.DurationInMins,
                CourseId= sessionCreateDto.CourseId
            };

            await _context.Sessions.AddAsync(sessionDb);

            await _context.SaveChangesAsync();

            var result = new SessionCreateDto()
            {
                Id = sessionDb.Id,
                SessionName = sessionDb.Name,
                DurationInMins = sessionDb.DurationInMins,
                CourseId=sessionDb.CourseId
                
            };
            return result;
        }

        public async Task<int> Update(SessionUpdateDto sessionUpdateDto)
        {
            if (sessionUpdateDto == null)
                throw new ArgumentException(nameof(sessionUpdateDto));

            var sessionDb = await _context.Sessions.FirstOrDefaultAsync(c => c.Id == sessionUpdateDto.Id);
            if (sessionDb == null) throw new ArgumentException(nameof(sessionDb));

            sessionDb.Name = sessionUpdateDto.SessionName;
            sessionDb.DurationInMins = sessionUpdateDto.DurationInMins;

            return await _context.SaveChangesAsync();
        }

    }
}
