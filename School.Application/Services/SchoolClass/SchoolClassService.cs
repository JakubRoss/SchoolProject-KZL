using AutoMapper;
using School.Application.Interfaces;
using School.Domain.Model.SchoolClassModels;
using School.Infrastructure.Interfaces;

namespace School.Application.Services.SchoolClass
{
    public class SchoolClassService : ISchoolClassService
    {
        private IBaseRepository<Infrastructure.Entities.SchoolClass> _baseRepository;
        private IMapper _mapper;
        private IBaseRepository<Infrastructure.Entities.Student> _studentBaseRepository;
        private IBaseRepository<Infrastructure.Entities.Teacher> _teacherBaseRepository;

        public SchoolClassService(IBaseRepository<Infrastructure.Entities.SchoolClass> baseRepository
            ,IMapper mapper
            ,IBaseRepository<Infrastructure.Entities.Student> studentBaseRepository
            ,IBaseRepository<Infrastructure.Entities.Teacher> teacherBaseRepository )
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _studentBaseRepository = studentBaseRepository;
            _teacherBaseRepository = teacherBaseRepository;
        }
        async Task<Infrastructure.Entities.SchoolClass> GetClass(string classId)
        {
            var schoolClass = await _baseRepository.ReadAsync(id => id.Id.ToString() == classId);
            if (schoolClass == null)
                throw new ResourceNotFoundException();
            return schoolClass;
        }

        //CRUD SchoolClass
        public async Task CreateAsync(SchoolClassDto classDto)
        {
            var schoolClass = _mapper.Map<Infrastructure.Entities.SchoolClass>(classDto);
            await _baseRepository.CreateAsync(schoolClass);
        }
        public async Task<Infrastructure.Entities.SchoolClass> ReadAsync(string classId)
        {
            return await _baseRepository.ReadIncludeAsync(i=>i.Id.ToString() == classId
            , s=>s.Students ,t=>t.Teachers);
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
        public async Task<List<Infrastructure.Entities.SchoolClass>> ReadAllAsync()
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
