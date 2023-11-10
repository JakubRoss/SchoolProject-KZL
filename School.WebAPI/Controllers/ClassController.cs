using Microsoft.AspNetCore.Mvc;
using School.WebAPI.Application.Interfaces;
using School.WebAPI.Application.Model.ClassModels;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private ISchoolClassesService _schoolClassesService;

        public ClassController(ISchoolClassesService schoolClassesService)
        {
            _schoolClassesService = schoolClassesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSchoolClass([FromBody] CreateUpdateClassDto schoolClassDto)
        {
            await _schoolClassesService.AddSchoolClass(schoolClassDto);
            return Ok("School class added successfully.");
        }

        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacherToClass([FromQuery] string teacherId, [FromQuery] string classId)
        {
            await _schoolClassesService.AddTeachertToClass(classId, teacherId);
            return Ok($"Teacher {teacherId} added to class {classId}.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchoolClass([FromQuery]string deleteClassId)
        {
            await _schoolClassesService.DeleteSchoolClass(deleteClassId);
            return Ok($"School class {deleteClassId} deleted successfully.");
        }

        [HttpDelete("deleteStudent")]
        public async Task<IActionResult> DeleteStudentFromClasses([FromQuery] string teacherId, [FromQuery] string classId)
        {
            await _schoolClassesService.DeleteTeacherFromClases(classId, teacherId);
            return Ok($"Teacher {teacherId} deleted from class {classId}.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetClasses()
        {
            var classes = await _schoolClassesService.GetClasses();
            return Ok(classes);
        }

        [HttpGet]
        public async Task<IActionResult> GetSchoolClass([FromQuery]string classId)
        {
            var schoolClass = await _schoolClassesService.GetSchoolClass(classId);
            return Ok(schoolClass);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchoolClass([FromBody] CreateUpdateClassDto schoolClassDto,[FromQuery] string classId)
        {
            await _schoolClassesService.UpdateSchoolClass(schoolClassDto, classId);
            return Ok($"School class {classId} updated successfully.");
        }
    }
}
