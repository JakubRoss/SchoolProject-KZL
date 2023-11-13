﻿using School.Application.Model.TeacherModels;

namespace School.Application.Interfasces
{
    public interface ITeacherService
    {
        //CRUD
        Task CreateAsync(TeacherDto teacherDto);
        Task DeleteAsync(string teacherId);
        Task<WebAPI.Domain.Entities.Teacher> ReadAsync(string teacherId);
        Task UpdateAsync(TeacherDto teacherDto, string teacherId);

        //
        Task<List<WebAPI.Domain.Entities.Teacher>> ReadAllAsync();
    }
}