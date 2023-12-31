﻿using AutoMapper;
using School.Application.Interfaces;
using School.Domain.Model.TeacherModels;
using School.Infrastructure.Interfaces;

namespace School.Application.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private IBaseRepository<Infrastructure.Entities.Teacher> _baseRepository;
        private IMapper _mapper;

        public TeacherService(IBaseRepository<Infrastructure.Entities.Teacher> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        async Task<Infrastructure.Entities.Teacher> GetTeacher(string teacherId)
        {
            Guid parsedId;
            if (Guid.TryParse(teacherId, out parsedId))
            {
                var teacher = await _baseRepository.ReadAsync(id => id.Id == parsedId);
                if (teacher == null)
                    throw new ResourceNotFoundException();
                return teacher;
            }
            throw new FormatException();
        }


        //CRUD Operations
        public async Task CreateAsync(TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Infrastructure.Entities.Teacher>(teacherDto);
            await _baseRepository.CreateAsync(teacher);
        }
        public async Task<Infrastructure.Entities.Teacher> ReadAsync(string teacherId)
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


        //
        public async Task<List<Infrastructure.Entities.Teacher>> ReadAllAsync()
        {
            return await _baseRepository.ReadAllAsync();
        }
    }
}
