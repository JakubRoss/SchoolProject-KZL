using School.WebAPI.Application.Model.TeacherModels;

namespace School.WebAPI.Application.Interfaces
{
    public interface ITeacherServices
    {
        Task AddTeacher(CreateTeacherDto teacherDto);
        Task DeleteTeacher(string teacherId);
        Task<ReadTeacherDto> GetTeacher(string id);
        Task<List<TeacherDto>> GetTeachers();
        Task UpdateTeacher(CreateTeacherDto teacherDto, string id);
    }
}