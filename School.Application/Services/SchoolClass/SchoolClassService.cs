using AutoMapper;
using Cabanoss.Core.Repositories.Impl;
using School.Application.Model.SchoolClassModels;
using School.WebAPI.Domain.Entities;

namespace School.Application.Services.SchoolClass
{
    public class SchoolClassService : ISchoolClassService
    {
        private IBaseRepository<WebAPI.Domain.Entities.SchoolClass> _baseRepository;
        private IMapper _mapper;
        private IBaseRepository<WebAPI.Domain.Entities.Student> _studentBaseRepository;

        public SchoolClassService(IBaseRepository<WebAPI.Domain.Entities.SchoolClass> baseRepository, IMapper mapper, IBaseRepository<WebAPI.Domain.Entities.Student> studentBaseRepository )
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _studentBaseRepository = studentBaseRepository;
        }

        async Task<WebAPI.Domain.Entities.SchoolClass> GetClass(string classId)
        {
            var student = await _baseRepository.ReadAsync(id => id.Id.ToString() == classId);
            return student;
        }

        public async Task CreateAsync(SchoolClassDto classDto)
        {
            var schoolClass = _mapper.Map<WebAPI.Domain.Entities.SchoolClass>(classDto);
            await _baseRepository.CreateAsync(schoolClass);
        }
        public async Task<WebAPI.Domain.Entities.SchoolClass> ReadAsync(string classId)
        {
            return await GetClass(classId);
        }

        public async Task UpdateAsync(SchoolClassDto classDto, string classId)
        {
            var classToUpdate = await GetClass(classId);
            classToUpdate.ClassName = classDto.ClassName;
            await _baseRepository.UpdateAsync(classToUpdate);
        }

        public async Task DeleteAsync(string classId)
        {
            await _baseRepository.DeleteAsync(await GetClass(classId));
        }

        public async Task<List<WebAPI.Domain.Entities.SchoolClass>> ReadAllAsync()
        {
            return await _baseRepository.ReadAllAsync();

        }


        //

        public async Task AddStudentAsync(string studentId, int classId)
        {
            var classWithStudents = await _baseRepository.ReadIncludeAsync(c => c.Id == classId, s => s.Students);
            var student = await _studentBaseRepository.ReadAsync(id => id.Id.ToString() == studentId);

            if (student == null || classWithStudents == null)
                throw new Exception();

            if (classWithStudents.Students == null)
                classWithStudents.Students = new List<WebAPI.Domain.Entities.Student>();

            if (!classWithStudents.Students.Contains(student))
            {
                classWithStudents.Students.Add(student);
                await _baseRepository.UpdateAsync(classWithStudents);
            }
        }

        public async Task DeleteStudentAsync(string studentId, int classId)
        {
            var classWithStudents = await _baseRepository.ReadIncludeAsync(c => c.Id == classId, s => s.Students);
            var student = await _studentBaseRepository.ReadAsync(id => id.Id.ToString() == studentId);

            if (student == null || classWithStudents == null)
                throw new Exception();

            student.SchoolClassId = null;
            await _studentBaseRepository.UpdateAsync(student);
        }
    }
}
