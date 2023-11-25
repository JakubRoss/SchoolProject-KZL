using School.Domain.Entities;
using School.Domain.Model.StudentModels;

namespace School.WebUI.Services.StudentService
{
    public interface IStudentsService
    {
        public List<StudentEM> Students { get; set; }
        public StudentDto StudentDto { get; set; }
        public StudentEM student { get; set; }
        //CRUD
        Task CreateAsync();
        Task DeleteAsync(string studentId);
        Task<StudentEM> ReadAsync(string studentId);
        Task UpdateAsync(StudentDto studentDto, string studentId);

        //
        Task ReadAllAsync();
        Task<List<StudentByPhraseDto>> SearchBy(string phrase);
    }
}
