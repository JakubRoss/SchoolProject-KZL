using School.Application.Model;
using School.WebAPI.Domain.Entities;

namespace School.Application.Services
{
    public interface IStudentService 
    {
        Task CreateAsync(StudentDto studentDto);
        Task DeleteAsync(string studentId);
        Task<Student> ReadAsync(string studentId);
        Task UpdateAsync(StudentDto studentDto, string studentId);
    }
}
