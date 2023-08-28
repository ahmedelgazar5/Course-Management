using CourseManagmentBLL.Managers.CourseLevelModule;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesLevelsController : ControllerBase
    {
        private ICourseLevelManager _courseLevelManager;
        public CoursesLevelsController(ICourseLevelManager courseLevelManager)
        {
            _courseLevelManager = courseLevelManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseLevelManager.GetAll());
        }
    }
}
