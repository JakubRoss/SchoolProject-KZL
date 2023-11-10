using School.WebAPI.Application.Model;

namespace School.WebAPI.Application.Interfaces
{
    public interface ITeacherServices
    {
        Task AddTeacher(CreateTeacherDto teacherDto);
        Task<List<TeacherDto>> GetTeachers();
        Task<ReadTeacherDto> GetTeacher(string teacherId);
        Task UpdateTeacher(CreateTeacherDto teacherDto, string teacherId);
        Task DeleteTeacher(string teacherId);
    }
}