using School.Domain.Model.SchoolClassModels;
using School.WebAPI.Domain.Entities;

namespace School.WebUI.Services.SchoolClassService
{
    public class SchoolClassService : ISchoolClassService
    {
        public Task AddStudentAsync(string studentId, int classId)
        {
            throw new NotImplementedException();
        }

        public Task AddTeacherAsync(string teacherId, int classId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(SchoolClassDto classDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string classId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(string studentId, int classId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeacherAsync(string teacherId, int classId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SchoolClass>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SchoolClass> ReadAsync(string classId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SchoolClassDto classDto, string classId)
        {
            throw new NotImplementedException();
        }
    }
}
