using CourseManagmentBLL.DTO.CourseDTO;
using CourseManagmentBLL.Managers.CourseModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CoursesController : ControllerBase
    {
        private ICourseManager _courseManager;
        public CoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CoursesQueryDto query)
        {
            return Ok(await _courseManager.GetAll(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourseCreateDto courseCreateDto)
        {
            if (courseCreateDto == null)
            {
                return BadRequest("Course data is missing.");
            }
            else
            {
                if (ModelState.IsValid == true)
                {
                    var course = await _courseManager.Create(courseCreateDto);
                    return Created("api/Courses/"+course.Id,course);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = (await _courseManager.GetById(id));
            if (course != null) return Ok(course);

            return NotFound();
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Put(CourseUpdateDto courseUpdate, int id)
        {
            var NumOfRowsAffected = await _courseManager.Update(courseUpdate,id);

            if (NumOfRowsAffected > 0) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //throw new Exception();
            var course = (await _courseManager.Delete(id));

            if (course != null) return Ok();
            await _courseManager.Delete(course);
            return NotFound();
        }
    }
}
