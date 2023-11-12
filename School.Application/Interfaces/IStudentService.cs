using School.Application.Model.StudentModels;

namespace School.Application.Interfasces
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
        Task<List<StudentByPhraseDto>> SearchBy(string phrase);
    }
}
