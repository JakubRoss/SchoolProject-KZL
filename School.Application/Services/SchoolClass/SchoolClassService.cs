using AutoMapper;
using Cabanoss.Core.Repositories.Impl;
using School.Application.Interfasces;
using School.Application.Model.SchoolClassModels;

namespace School.Application.Services.SchoolClass
{
    public class SchoolClassService : ISchoolClassService
    {
        private IBaseRepository<WebAPI.Domain.Entities.SchoolClass> _baseRepository;
        private IMapper _mapper;
        private IBaseRepository<WebAPI.Domain.Entities.Student> _studentBaseRepository;
        private IBaseRepository<WebAPI.Domain.Entities.Teacher> _teacherBaseRepository;

        public SchoolClassService(IBaseRepository<WebAPI.Domain.Entities.SchoolClass> baseRepository
            ,IMapper mapper
            ,IBaseRepository<WebAPI.Domain.Entities.Student> studentBaseRepository
            ,IBaseRepository<WebAPI.Domain.Entities.Teacher> teacherBaseRepository )
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _studentBaseRepository = studentBaseRepository;
            _teacherBaseRepository = teacherBaseRepository;
        }
        async Task<WebAPI.Domain.Entities.SchoolClass> GetClass(string classId)
        {
            var schoolClass = await _baseRepository.ReadAsync(id => id.Id.ToString() == classId);
            if (schoolClass == null)
                throw new ResourceNotFoundException();
            return schoolClass;
        }

        //CRUD SchoolClass
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


        //
        public async Task<List<WebAPI.Domain.Entities.SchoolClass>> ReadAllAsync()
        {
            return await _baseRepository.ReadAllAsync(i=>i.Students,t=>t.Teachers);
        }

        // Adding/Removing Students from SSchoolClass

        public async Task AddStudentAsync(string studentId, int classId)
        {
            var classWithStudents = await _baseRepository.ReadIncludeAsync(c => c.Id == classId, s => s.Students);
            var student = await _studentBaseRepository.ReadAsync(id => id.Id.ToString() == studentId);

            if (student == null || classWithStudents == null)
                throw new ResourceNotFoundException();

            classWithStudents.Students.Add(student);
            await _baseRepository.UpdateAsync(classWithStudents);
            
        }

        public async Task DeleteStudentAsync(string studentId, int classId)
        {
            var classWithStudents = await _baseRepository.ReadIncludeAsync(c => c.Id == classId, s => s.Students);
            var student = classWithStudents.Students.FirstOrDefault(id => id.Id == Guid.Parse(studentId));

            if (student == null || classWithStudents == null)
                throw new ResourceNotFoundException();

            student.SchoolClassId = null;
            await _studentBaseRepository.UpdateAsync(student);
        }

        // Adding/Removing Teachers from schoolClasses

        public async Task AddTeacherAsync(string teacherId, int classId)
        {
            var teacher = await _teacherBaseRepository.ReadAsync(id=>id.Id.ToString() == teacherId);
            var classWithTeachers = await _baseRepository.ReadIncludeAsync(id => id.Id == classId, i => i.Teachers);

            if(classWithTeachers == null || teacher == null)
                throw new ResourceNotFoundException();

            classWithTeachers.Teachers.Add(teacher);
            _baseRepository.UpdateAsync(classWithTeachers);
        }

        public async Task DeleteTeacherAsync(string teacherId, int classId)
        {
            var classWithTeachers = await _baseRepository.ReadIncludeAsync(id => id.Id == classId, i => i.Teachers);

            if (classWithTeachers == null || classWithTeachers.Teachers == null)
                throw new ResourceNotFoundException();

            var teacher = classWithTeachers.Teachers.FirstOrDefault(id => id.Id == Guid.Parse(teacherId));
            if (teacher == null)
                throw new ResourceNotFoundException();

            classWithTeachers.Teachers.Remove(teacher);
            await _baseRepository.UpdateAsync(classWithTeachers);
        }
    }
}
