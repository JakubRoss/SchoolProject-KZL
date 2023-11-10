using School.WebAPI.Application.Model.ClassModels;

namespace School.WebAPI.Application.Interfaces
{
    public interface ISchoolClassesService
    {
        Task AddSchoolClass(CreateUpdateClassDto SchoolClassDto);
        Task AddStudentToClass(string ClassId, string studentId);
        Task AddTeachertToClass(string ClassId, string teacherId);
        Task DeleteSchoolClass(string ClassId);
        Task DeleteStudentFromClases(string ClassId, string studentId);
        Task DeleteTeacherFromClases(string ClassId, string teacherId);
        Task<List<ClassDto>> GetClasses();
        Task<CreateUpdateClassDto> GetSchoolClass(string ClassId);
        Task UpdateSchoolClass(CreateUpdateClassDto SchoolClassDto, string ClassId);
    }
}