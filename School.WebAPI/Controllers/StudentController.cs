using Microsoft.AspNetCore.Mvc;
using School.Application.Interfaces;
using School.Domain.Model.StudentModels;
using School.WebAPI.Domain.Entities;

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
        public async Task<Student> Read([FromQuery] string studentId)
        {
            return await _studentService.ReadAsync(studentId);
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

        [HttpGet("all")]
        public async Task<IActionResult> ReadAll()
        {
            return Ok(await _studentService.ReadAllAsync());
        }

        [HttpGet("{searchPhrase}")]
        public async Task<IActionResult> ReadByName([FromRoute]string searchPhrase)
        {
            return Ok(await _studentService.SearchBy(searchPhrase));
        }
    }
}
