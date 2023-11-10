using AutoMapper;
using School.WebAPI.Application.Interfaces;
using School.WebAPI.Application.Model.TeacherModels;
using School.WebAPI.Database;
using System.Data;
using System.Data.SqlClient;

namespace School.WebAPI.Application.Services
{
    public class TeacherServices : ITeacherServices
    {
        private DatabaseService _databaseService;
        private IMapper _mapper;


        //brak obsulgi nulli i bledow watchout!
        public TeacherServices(DatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<List<TeacherDto>> GetTeachers()
        {
            string query = "SELECT * FROM Teacher";
            DataTable result = await _databaseService.ExecuteQuery(query);

            var DataRows = new List<DataRow>();

            foreach (DataRow DataRow in result.Rows)
            {
                DataRows.Add(DataRow);
            }

            return _mapper.Map<List<TeacherDto>>(DataRows);
        }

        public async Task<ReadTeacherDto> GetTeacher(string id)
        {
            string query = "SELECT * FROM Teacher WHERE Id=@Id";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            DataTable result = await _databaseService.ExecuteQuery(query, sqlParameter);

            var DataRows = result.Rows[0];

            var readteacherDto = _mapper.Map<ReadTeacherDto>(DataRows);
            return readteacherDto;
        }

        public async Task AddTeacher(CreateTeacherDto teacherDto)
        {
            var date = DateTime.Now.Date;
            string query = "INSERT INTO Teacher (Name, Surname, Post, StartOfWork) VALUES (@Name, @Surname, @Post, @StartOfWork)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", teacherDto.Name),
                new SqlParameter("@Surname", teacherDto.Surname),
                new SqlParameter("@Post", teacherDto.Post),
                new SqlParameter("@StartOfWork",date)
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }

        public async Task UpdateTeacher(CreateTeacherDto teacherDto, string id)
        {
            string query = "UPDATE Teacher SET Name = @Name, Surname = @Surname, Post = @Post WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id),
                new SqlParameter("@Name", teacherDto.Name),
                new SqlParameter("@Surname", teacherDto.Surname),
                new SqlParameter("@Post", teacherDto.Post),
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }


        public async Task DeleteTeacher(string teacherId)
        {
            string query = "DELETE FROM Teacher WHERE Id = @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", teacherId),

            };
            await _databaseService.ExecuteNonQuery(query, parameters);
        }
    }
}
