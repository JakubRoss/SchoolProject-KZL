using Microsoft.AspNetCore.Mvc;
using School.Application.Model.SchoolClassModels;
using School.Application.Services.SchoolClass;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private ISchoolClassService _service;

        public ClassController(ISchoolClassService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SchoolClassDto schoolClassDto)
        {
            await _service.CreateAsync(schoolClassDto);
            return Ok();
        }
        [HttpGet("all")]
        public async Task<IActionResult> ReadAll()
        {
            return Ok(await _service.ReadAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Read([FromQuery] string schoolClassId)
        {
            return Ok(await _service.ReadAsync(schoolClassId));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SchoolClassDto schoolClassDto, string schoolClassId)
        {
            await _service.UpdateAsync(schoolClassDto, schoolClassId);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string schoolClassId)
        {
            await _service.DeleteAsync(schoolClassId);
            return Ok();
        }


        [HttpPost("students")]
        public async Task<IActionResult> AddStudent([FromQuery] string studentId ,int classId)
        {
            await _service.AddStudentAsync(studentId,classId);
            return Ok();
        }

        [HttpDelete("students")]
        public async Task<IActionResult> DeleteStudent([FromQuery] string studentId, int classId)
        {
            await _service.DeleteStudentAsync(studentId, classId);
            return Ok();
        }
    }
}
