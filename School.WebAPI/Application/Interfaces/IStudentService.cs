using School.WebAPI.Application.Model.Studentmodels;
using School.WebAPI.Application.Model.StudentModels;

namespace School.WebAPI.Application.Interfaces
{
    public interface IStudentService
    {
        Task AddStudent(CreateStudentDto studentDto);
        Task DeleteStudent(string studentId);
        Task<UpdateStudentDto> GetStudent(string studentId);
        Task<List<StudentDto>> GetStudents();
        Task UpdateStudent(UpdateStudentDto studentDto, string StudentId);
    }
}