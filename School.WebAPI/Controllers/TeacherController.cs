using Microsoft.AspNetCore.Mvc;
using School.Application.Interfasces;
using School.Application.Model.TeacherModels;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherDto teacherDto)
        {
            await _teacherService.CreateAsync(teacherDto);
            return Ok();
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAll()
        {
            return Ok(await _teacherService.ReadAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Read([FromQuery] string teacherId)
        {
            return Ok(await _teacherService.ReadAsync(teacherId));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TeacherDto teacherDto, string teacherId)
        {
            await _teacherService.UpdateAsync(teacherDto, teacherId);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string teacherId)
        {
            await _teacherService.DeleteAsync(teacherId);
            return Ok();
        }
    }
}
