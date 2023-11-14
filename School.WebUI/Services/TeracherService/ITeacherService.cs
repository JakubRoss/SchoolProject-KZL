using School.Domain.Model.TeacherModels;
using School.WebAPI.Domain.Entities;

namespace School.WebUI.Services.TeracherService
{
    public interface ITeacherService
    {
        public List<Teacher> Teachers { get; set; }
        //CRUD
        Task CreateAsync(TeacherDto teacherDto);
        Task DeleteAsync(string teacherId);
        Task<WebAPI.Domain.Entities.Teacher> ReadAsync(string teacherId);
        Task UpdateAsync(TeacherDto teacherDto, string teacherId);

        //
        Task ReadAllAsync();
    }
}
