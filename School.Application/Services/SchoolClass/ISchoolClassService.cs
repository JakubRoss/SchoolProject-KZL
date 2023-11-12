using School.Application.Model.SchoolClassModels;

namespace School.Application.Services.SchoolClass
{
    public interface ISchoolClassService
    {
        Task CreateAsync(SchoolClassDto classDto);
        Task DeleteAsync(string classId);
        Task<List<WebAPI.Domain.Entities.SchoolClass>> ReadAllAsync();
        Task<WebAPI.Domain.Entities.SchoolClass> ReadAsync(string classId);
        Task UpdateAsync(SchoolClassDto classDto, string classId);

        Task AddStudentAsync(string studentId, int classId);
        Task DeleteStudentAsync(string studentId, int classId);
    }
}