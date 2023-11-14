using School.Domain.Model.SchoolClassModels;
using School.WebAPI.Domain.Entities;

namespace School.WebUI.Services.SchoolClassService
{
    public interface ISchoolClassService
    {
        List<SchoolClass> SchoolClasses { get; set; }
        //CRUD SchoolClass
        Task CreateAsync(SchoolClassDto classDto);
        Task DeleteAsync(string classId);
        Task ReadAllAsync();
        Task<WebAPI.Domain.Entities.SchoolClass> ReadAsync(string classId);
        Task UpdateAsync(SchoolClassDto classDto, string classId);

        // Adding/Removing Students from SSchoolClass
        Task AddStudentAsync(string studentId, int classId);
        Task DeleteStudentAsync(string studentId, int classId);

        // Adding/Removing Teachers from schoolClasses
        Task AddTeacherAsync(string teacherId, int classId);
        Task DeleteTeacherAsync(string teacherId, int classId);
    }
}
