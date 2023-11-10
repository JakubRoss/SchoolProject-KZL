using AutoMapper;
using School.WebAPI.Application.Interfaces;
using School.WebAPI.Application.Model.Studentmodels;
using School.WebAPI.Application.Model.StudentModels;
using School.WebAPI.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace School.WebAPI.Application.Services
{
    public class StudentService : IStudentService
    {
        private DatabaseService _databaseService;
        private IMapper _mapper;

        public StudentService(DatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<List<StudentDto>> GetStudents()
        {
            string query = "SELECT * FROM Student";
            DataTable result = await _databaseService.ExecuteQuery(query);

            var DataRows = new List<DataRow>();

            foreach (DataRow DataRow in result.Rows)
            {
                DataRows.Add(DataRow);
            }

            return _mapper.Map<List<StudentDto>>(DataRows);
        }

        public async Task<UpdateStudentDto> GetStudent(string studentId)
        {
            string query = "SELECT * FROM Student WHERE Id=@Id";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@Id", studentId)
            };
            DataTable result = await _databaseService.ExecuteQuery(query, sqlParameter);

            var DataRows = result.Rows[0];

            var readteacherDto = _mapper.Map<UpdateStudentDto>(DataRows);
            return readteacherDto;
        }

        public async Task AddStudent(CreateStudentDto studentDto)
        {
            string query = "INSERT INTO Student (Name, Surname, DateOfBirth) VALUES (@Name, @Surname, @DateOfBirth)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", studentDto.Name),
                new SqlParameter("@Surname", studentDto.Surname),
                new SqlParameter("@DateOfBirth", studentDto.DateOfBirth.ToDateTime(TimeOnly.MinValue))
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }

        public async Task UpdateStudent(UpdateStudentDto studentDto, string StudentId)
        {
            string query = "UPDATE Student SET Name = @Name, Surname = @Surname, DateOfBirth = @DateOfBirth, GradeAvarage = @GradeAvarage, ClassId = @ClassId WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",StudentId),
                new SqlParameter("@Name", studentDto.Name),
                new SqlParameter("@Surname", studentDto.Surname),
                new SqlParameter("@DateOfBirth", studentDto.DateOfBirth.Date),
                new SqlParameter("@GradeAvarage", studentDto.GradeAvarage),
                new SqlParameter("@ClassId",studentDto.CalssId)
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }


        public async Task DeleteStudent(string studentId)
        {
            string deleteTeachersClassesQuery = "DELETE FROM Student WHERE Id = @Id";
            SqlParameter[] teachersClassesParameters = new SqlParameter[]
            {
                new SqlParameter("@Id", studentId)
            };
            await _databaseService.ExecuteNonQuery(deleteTeachersClassesQuery, teachersClassesParameters);
        }
    }
}
