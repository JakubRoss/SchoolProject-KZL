using School.Application.Model;

namespace School.Application.Services.Teacher
{
    public interface ITeacherService
    {
        Task CreateAsync(TeacherDto teacherDto);
        Task DeleteAsync(string teacherId);
        Task<WebAPI.Domain.Entities.Teacher> ReadAsync(string teacherId);
        Task UpdateAsync(TeacherDto teacherDto, string teacherId);
    }
}