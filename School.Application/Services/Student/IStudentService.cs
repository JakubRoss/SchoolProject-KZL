using School.Application.Model.StudentModels;

namespace School.Application.Services.Student
{
    public interface IStudentService
    {
        //CRUD
        Task CreateAsync(StudentDto studentDto);
        Task DeleteAsync(string studentId);
        Task<WebAPI.Domain.Entities.Student> ReadAsync(string studentId);
        Task UpdateAsync(StudentDto studentDto, string studentId);

        //
        Task<List<WebAPI.Domain.Entities.Student>> ReadAllAsync();
    }
}
