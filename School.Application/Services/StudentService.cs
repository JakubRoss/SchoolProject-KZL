using AutoMapper;
using Cabanoss.Core.Repositories.Impl;
using School.Application.Model;
using School.WebAPI.Domain.Entities;

namespace School.Application.Services
{
    public class StudentService : IStudentService
    {
        private IBaseRepository<Student> _baseRepository;
        private IMapper _mapper;

        public StudentService(IBaseRepository<Student> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        async Task<Student> GetStudent(string studentId)
        {
            var student = await _baseRepository.ReadAsync(id => id.Id.ToString() == studentId);
            return student;
        }

        public async Task CreateAsync (StudentDto studentDto)
        {
            var student =_mapper.Map<Student>(studentDto);
            await _baseRepository.CreateAsync(student);
        }
        public async Task<Student> ReadAsync(string studentId)
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
