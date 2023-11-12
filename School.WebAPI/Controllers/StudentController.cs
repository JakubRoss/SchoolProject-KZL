using Microsoft.AspNetCore.Mvc;
using School.Application.Model.StudentModels;
using School.Application.Services.Student;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDto studentDto)
        {
            await _studentService.CreateAsync(studentDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Read([FromQuery] string studentId)
        {
            return Ok(await _studentService.ReadAsync(studentId));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StudentDto studentDto , string studentId)
        {
            await _studentService.UpdateAsync(studentDto, studentId);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string studentId)
        {
            await _studentService.DeleteAsync(studentId);
            return Ok();
        }
    }
}
