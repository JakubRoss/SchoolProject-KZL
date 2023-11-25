using School.Domain.Entities;
using School.Domain.Model.TeacherModels;
using School.Infrastructure.Entities;

namespace School.Application.Interfaces
{
    public interface ITeacherService
    {
        //CRUD
        Task CreateAsync(TeacherDto teacherDto);
        Task DeleteAsync(string teacherId);
        Task<Teacher> ReadAsync(string teacherId);
        Task UpdateAsync(TeacherDto teacherDto, string teacherId);

        //
        Task<List<Teacher>> ReadAllAsync();
    }
}