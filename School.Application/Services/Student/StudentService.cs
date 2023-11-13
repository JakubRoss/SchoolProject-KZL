using AutoMapper;
using Cabanoss.Core.Repositories.Impl;
using School.Application.Interfaces;
using School.Domain.Model.StudentModels;

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

            Guid parsedId;
            if (Guid.TryParse(studentId, out parsedId))
            {
                var student = await _baseRepository.ReadAsync(id => id.Id == parsedId);
                if (student == null)
                    throw new ResourceNotFoundException();
                return student;
            }
            throw new FormatException();
        }

        //CRUD Operations
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

        //
        public async Task<List<WebAPI.Domain.Entities.Student>> ReadAllAsync()
        {
            return await _baseRepository.ReadAllAsync();
        }
        public async Task<List<StudentByPhraseDto>> SearchBy(string phrase)
        {
            var allStudents = await _baseRepository.ReadAllAsync(i=>i.SchoolClass);

            phrase = phrase.ToLower();
            var students = allStudents.Where(n => n.Name.ToLower().Contains(phrase) || n.Surname.ToLower().Contains(phrase) ||(n.SchoolClass != null && n.SchoolClass.ClassName.ToLower().Contains(phrase))).ToList();
            var studentPhrases = new List<StudentByPhraseDto>();
            foreach (var student in students)
            {
                var studentPhraseDto = new StudentByPhraseDto();
                studentPhraseDto.Name = student.Name;
                studentPhraseDto.Surname = student.Surname;
                studentPhraseDto.ClassName = student.SchoolClass == null ? "Bez klasy " : student.SchoolClass.ClassName;

                studentPhrases.Add(studentPhraseDto);
            }
            return studentPhrases;
        }
    }
}
