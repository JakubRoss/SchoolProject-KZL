using AutoMapper;
using School.WebAPI.Application.Interfaces;
using School.WebAPI.Application.Model.ClassModels;
using School.WebAPI.Database;
using System.Data;
using System.Data.SqlClient;

namespace School.WebAPI.Application.Services
{
    public class SchoolClassesService : ISchoolClassesService
    {
        private DatabaseService _databaseService;
        private IMapper _mapper;

        public SchoolClassesService(DatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<ClassDto>> GetClasses()
        {
            var query = "SELECT * FROM SchoolClass";
            var classes = await _databaseService.ExecuteQuery(query);

            List<DataRow> result = new List<DataRow>();
            foreach (DataRow row in classes.Rows)
            {
                result.Add(row);
            }
            var classList = _mapper.Map<List<ClassDto>>(result);
            return classList;
        }

        public async Task<CreateUpdateClassDto> GetSchoolClass(string ClassId)
        {
            var query = "SELECT * FROM SchoolClass WHERE Id = @Id";
            var sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Id", ClassId)
            };

            var classes = await _databaseService.ExecuteQuery(query, sqlParameters);

            var classList = _mapper.Map<CreateUpdateClassDto>(classes.Rows[0]);
            return classList;
        }

        public async Task AddSchoolClass(CreateUpdateClassDto SchoolClassDto)
        {
            string query = "INSERT INTO SchoolClass (ClassName) VALUES (@Name)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", SchoolClassDto.ClassName),
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }

        public async Task UpdateSchoolClass(CreateUpdateClassDto SchoolClassDto, string ClassId)
        {
            string query = "UPDATE SchoolClass SET ClassName = @name WHERE Id = @Id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@name",SchoolClassDto.ClassName),
                new SqlParameter("@Id",ClassId)
            };
            await _databaseService.ExecuteNonQuery(query, sqlParameters);
        }


        public async Task DeleteSchoolClass(string ClassId)
        {
            // Usun powiązane rekordy z tabeli TeachersClasses
            string updateQuery = "UPDATE Student SET CalssId = NULL WHERE ClassId = @ClassId";
            SqlParameter[] StudentParameters = new SqlParameter[]
            {
                new SqlParameter("@ClassId", ClassId),
            };
            await _databaseService.ExecuteNonQuery(updateQuery, StudentParameters);

            string deleteTeachersClassesQuery = "DELETE FROM TeachersClasses WHERE SchoolClassID = @ClassId";
            SqlParameter[] teachersClassesParameters = new SqlParameter[]
            {
                new SqlParameter("@ClassId", ClassId),
            };
            await _databaseService.ExecuteNonQuery(deleteTeachersClassesQuery, teachersClassesParameters);

            string query = "DELETE FROM SchoolClass WHERE Id =@Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", ClassId),
            };
            await _databaseService.ExecuteNonQuery(query, parameters);
        }

        public async Task AddTeachertToClass(string ClassId, string teacherId)
        {
            string query = "INSERT INTO TeachersClasses (SchoolClassID , TeacherId) VALUES (@ClassId, @TeacherID)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ClassId",ClassId),
                new SqlParameter("@TeacherId",teacherId),
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }

        public async Task DeleteTeacherFromClases(string ClassId, string teacherId)
        {
            string query = " DELETE FROM TeachersClasses WHERE TeacherId = @TeacherId AND SchoolClassID = @ClassId)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ClassId",ClassId),
                new SqlParameter("@TeacherId",teacherId),
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }
        public async Task AddStudentToClass(string ClassId, string studentId)
        {
            string studentsClassesQuery = "INSERT INTO StudentsClasses (StudentId, SchoolClassId) VALUES (@StudentId, @SchoolClassId)";
            var studentsClassesParams = new SqlParameter[]
            {
                new SqlParameter("@StudentId", studentId),
                new SqlParameter("@SchoolClassId",ClassId)
            };
            await _databaseService.ExecuteNonQuery(studentsClassesQuery, studentsClassesParams);

            string query = "UPDATE Student SET ClassId = @ClassId WHERE Id = @StudentId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ClassId",ClassId),
                new SqlParameter("@StudentId",studentId),
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }

        public async Task DeleteStudentFromClases(string ClassId, string studentId)
        {
            string deleteStudentClasses = "DELETE FROM StudentsClasses WHERE StudentId = @studentId";
            var deleteStudentsParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentId", ClassId),
                new SqlParameter("@SchoolClassId",studentId)
            };
            await _databaseService.ExecuteNonQuery(deleteStudentClasses, deleteStudentsParameters);

            string query = "UPDATE Student SET ClassId = NULL WHERE Id = @studentId AND ClassId = @ClassId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ClassId",ClassId),
                new SqlParameter("@studentId",studentId),
            };

            await _databaseService.ExecuteNonQuery(query, parameters);
        }
    }
}
