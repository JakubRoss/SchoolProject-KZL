using School.Domain.Model.StudentModels;
using School.Infrastructure.Entities;

namespace School.Application.Interfaces
{
    public interface IStudentService
    {
        //CRUD
        Task CreateAsync(StudentDto studentDto);
        Task DeleteAsync(string studentId);
        Task<Student> ReadAsync(string studentId);
        Task UpdateAsync(StudentDto studentDto, string studentId);

        //
        Task<List<Student>> ReadAllAsync();
        Task<List<StudentByPhraseDto>> SearchBy(string phrase);
    }
}
