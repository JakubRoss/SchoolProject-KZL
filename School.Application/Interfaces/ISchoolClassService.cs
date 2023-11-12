using School.Application.Model.SchoolClassModels;

namespace School.Application.Interfasces
{
    public interface ISchoolClassService
    {
        //CRUD SchoolClass
        Task CreateAsync(SchoolClassDto classDto);
        Task DeleteAsync(string classId);
        Task<List<WebAPI.Domain.Entities.SchoolClass>> ReadAllAsync();
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