using Microsoft.AspNetCore.Mvc;
using School.WebAPI.Application.Interfaces;
using School.WebAPI.Application.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherServices _teacherServices;

        public TeacherController(ITeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherServices.GetTeachers();
            return Ok(teachers);
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacher(string teacherId)
        {
            var teacher = await _teacherServices.GetTeacher(teacherId);
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] CreateTeacherDto nauczyciel)
        {
            await _teacherServices.AddTeacher(nauczyciel);
            return Ok("Nauczyciel został dodany.");
        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> UpdateTeacher([FromBody] CreateTeacherDto nauczyciel, string teacherId)
        {
            await _teacherServices.UpdateTeacher(nauczyciel, teacherId);
            return Ok("Nauczyciel został zmodyfikowany.");
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> DeleteTeacher(string teacherId)
        {
            await _teacherServices.DeleteTeacher(teacherId);
            return Ok("Nauczyciel został usunięty.");
        }
    }
}
