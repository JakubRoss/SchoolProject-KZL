using AutoMapper;
using Cabanoss.Core.Repositories.Impl;
using School.Application.Model.TeacherModels;

namespace School.Application.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private IBaseRepository<WebAPI.Domain.Entities.Teacher> _baseRepository;
        private IMapper _mapper;

        public TeacherService(IBaseRepository<WebAPI.Domain.Entities.Teacher> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        async Task<WebAPI.Domain.Entities.Teacher> GetTeacher(string studentId)
        {
            var student = await _baseRepository.ReadAsync(id => id.Id.ToString() == studentId);
            return student;
        }

        public async Task CreateAsync(TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<WebAPI.Domain.Entities.Teacher>(teacherDto);
            await _baseRepository.CreateAsync(teacher);
        }
        public async Task<WebAPI.Domain.Entities.Teacher> ReadAsync(string teacherId)
        {
            return await GetTeacher(teacherId);
        }

        public async Task UpdateAsync(TeacherDto teacherDto, string teacherId)
        {
            var studentToUpdate = await GetTeacher(teacherId);
            studentToUpdate.Name = teacherDto.Name;
            studentToUpdate.Surname = teacherDto.Surname;
            studentToUpdate.StartOfWork = teacherDto.StartOfWork;
            await _baseRepository.UpdateAsync(studentToUpdate);
        }

        public async Task DeleteAsync(string teacherId)
        {
            await _baseRepository.DeleteAsync(await GetTeacher(teacherId));
        }
    }
}
