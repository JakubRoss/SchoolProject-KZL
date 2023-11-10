using Microsoft.AspNetCore.Mvc;
using School.WebAPI.Application.Interfaces;
using School.WebAPI.Application.Model.StudentModels;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentDto studentDto)
        {
            await _studentService.AddStudent(studentDto);
            return Ok("Student added successfully.");
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            await _studentService.DeleteStudent(studentId);
            return Ok($"Student {studentId} deleted successfully.");
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(string studentId)
        {
            var student = await _studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound($"Student with ID {studentId} not found.");
            }
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudents();
            return Ok(students);
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDto studentDto, string studentId)
        {
            await _studentService.UpdateStudent(studentDto, studentId);
            return Ok($"Student {studentId} updated successfully.");
        }
    }
}
