using AutoMapper;
using Cabanoss.Core.Repositories.Impl;
using School.Application.Model;

namespace School.Application.Services.Student
{
    public class StudentService : IStudentService
    {
        private IBaseRepository<WebAPI.Domain.Entities.Student> _baseRepository;
        private IMapper _mapper;

        public StudentService(IBaseRepository<WebAPI.Domain.Entities.Student> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        async Task<WebAPI.Domain.Entities.Student> GetStudent(string studentId)
        {
            var student = await _baseRepository.ReadAsync(id => id.Id.ToString() == studentId);
            return student;
        }

        public async Task CreateAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<WebAPI.Domain.Entities.Student>(studentDto);
            await _baseRepository.CreateAsync(student);
        }
        public async Task<WebAPI.Domain.Entities.Student> ReadAsync(string studentId)
        {
            return await GetStudent(studentId);
        }

        public async Task UpdateAsync(StudentDto studentDto, string studentId)
        {
            var studentToUpdate = await GetStudent(studentId);
            studentToUpdate.Name = studentDto.Name;
            studentToUpdate.Surname = studentDto.Surname;
            studentToUpdate.DateOfBirth = studentDto.DateOfBirth;
            await _baseRepository.UpdateAsync(studentToUpdate);
        }

        public async Task DeleteAsync(string studentId)
        {
            await _baseRepository.DeleteAsync(await GetStudent(studentId));
        }
    }
}
