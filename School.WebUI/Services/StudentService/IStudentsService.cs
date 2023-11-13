using School.Domain.Model.StudentModels;
using School.WebAPI.Domain.Entities;

namespace School.WebUI.Services.StudentService
{
    public interface IStudentsService
    {
        public List<Student> Students { get; set; }
        public StudentDto StudentDto { get; set; }
        public Student student { get; set; }
        //CRUD
        Task CreateAsync();
        Task DeleteAsync(string studentId);
        Task<Student> ReadAsync(string studentId);
        Task UpdateAsync(StudentDto studentDto, string studentId);

        //
        Task ReadAllAsync();
        Task<List<StudentByPhraseDto>> SearchBy(string phrase);
    }
}
