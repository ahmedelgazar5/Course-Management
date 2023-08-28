using CourseManagmentBLL.DTO.CourseDTO;
using CourseManagmentBLL.DTO.SessionDto;
using CourseManagmentBLL.Managers.SessionsModule;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private ISessionsManager _sessionsManager;
        public SessionsController(ISessionsManager sessionsManager)
        {
            _sessionsManager = sessionsManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sessionsManager.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(SessionCreateDto sessionCreateDto)
        {
            if (sessionCreateDto == null)
            {
                return BadRequest("Course data is missing.");
            }
            else
            {
                if (ModelState.IsValid == true)
                {
                    var session = await _sessionsManager.Create(sessionCreateDto);
                    return Created("api/Courses/" + session.Id, session);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(SessionUpdateDto sessionUpdateDto)
        {
            var NumOfRowsAffected = await _sessionsManager.Update(sessionUpdateDto);

            if (NumOfRowsAffected > 0) return Ok();
            return NotFound();
        }

    }
}
