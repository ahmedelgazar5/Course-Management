using CourseManagmentBLL.Managers.CourseTypeModule;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesTypesController : ControllerBase
    {
        private ICourseTypeManager _courseTypeManager;
        public CoursesTypesController(ICourseTypeManager courseTypeManager)
        {
            _courseTypeManager = courseTypeManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseTypeManager.GetAll());
        }
    }
}
