using School.Domain.Entities;
using School.Domain.Model.TeacherModels;

namespace School.WebUI.Services.TeracherService
{
    public interface ITeacherService
    {
        public List<TeacherEM> Teachers { get; set; }
        //CRUD
        Task CreateAsync(TeacherDto teacherDto);
        Task DeleteAsync(string teacherId);
        Task<TeacherEM> ReadAsync(string teacherId);
        Task UpdateAsync(TeacherDto teacherDto, string teacherId);

        //
        Task ReadAllAsync();
    }
}
