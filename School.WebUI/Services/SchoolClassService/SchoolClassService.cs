using School.Domain.Model.SchoolClassModels;
using School.WebAPI.Domain.Entities;
using School.WebUI.Pages.TeacherPages;
using System.Security.Claims;

namespace School.WebUI.Services.SchoolClassService
{
    public class SchoolClassService : ISchoolClassService
    {
        private HttpClient _httpClient;

        public SchoolClassService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
        public async Task AddStudentAsync(string studentId, int classId)
        {
            await _httpClient.PostAsync($"api/Class/students?studentId={studentId}&classId={classId}",null);
        }

        public async Task AddTeacherAsync(string teacherId, int classId)
        {
            await _httpClient.PostAsync($"api/Class/teachers?teacherId={teacherId}&classId={classId}", null);
        }

        public async Task CreateAsync(SchoolClassDto classDto)
        {
            await _httpClient.PostAsJsonAsync("api/Class", classDto);
        }

        public async Task DeleteAsync(string classId)
        {
            await _httpClient.DeleteAsync($"api/Class?schoolClassId={classId}");
        }

        public async Task DeleteStudentAsync(string studentId, int classId)
        {
            await _httpClient.DeleteAsync($"/api/Class/students?studentId={studentId}&classId={classId}");
        }

        public async Task DeleteTeacherAsync(string teacherId, int classId)
        {
            await _httpClient.DeleteAsync($"api/Class/teachers?teacherId={teacherId}&classId={classId}");
        }

        public async Task ReadAllAsync()
        {
            var result = await _httpClient.GetAsync($"api/Class/all");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var classes = await result.Content.ReadFromJsonAsync<List<SchoolClass>>();
                if (classes != null)
                    SchoolClasses = classes;
            }

        }

        public async Task<SchoolClass> ReadAsync(string classId)
        {
            var result = await _httpClient.GetAsync($"api/Class?schoolClassId={classId}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<SchoolClass>();
            }
            return new SchoolClass();
        }

        public async Task UpdateAsync(SchoolClassDto classDto, string classId)
        {
            await _httpClient.PutAsJsonAsync($"api/Class?schoolClassId={classId}", classDto);
        }
    }
}
