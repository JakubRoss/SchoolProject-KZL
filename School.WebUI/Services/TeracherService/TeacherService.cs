using School.Domain.Model.StudentModels;
using School.Domain.Model.TeacherModels;
using School.WebAPI.Domain.Entities;

namespace School.WebUI.Services.TeracherService
{
    public class TeacherService : ITeacherService
    {
        private HttpClient _httpClient;

        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<WebAPI.Domain.Entities.Teacher> Teachers { get; set; } = new List<WebAPI.Domain.Entities.Teacher>();
        public async Task CreateAsync(TeacherDto teacherDto)
        {
            await _httpClient.PostAsJsonAsync("/api/Teacher", teacherDto);
        }

        public async Task DeleteAsync(string teacherId)
        {
            await _httpClient.DeleteAsync($"/api/Teacher?teacherId={teacherId}");
        }

        public async Task ReadAllAsync()
        {
            var students = await _httpClient.GetFromJsonAsync<List<WebAPI.Domain.Entities.Teacher>>("api/Teacher/all");
            if (students != null)
                Teachers = students;
        }

        public async Task<WebAPI.Domain.Entities.Teacher> ReadAsync(string teacherId)
        {
            var result = await _httpClient.GetAsync($"api/Teacher?teacherId={teacherId}");
            var teacherN= new Teacher();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var teacherQ= await result.Content.ReadFromJsonAsync<WebAPI.Domain.Entities.Teacher>();
                if(teacherQ != null)
                    return teacherQ;
                return teacherN;
            }
            return teacherN;
        }

        public async Task UpdateAsync(TeacherDto teacherDto, string teacherId)
        {
            await _httpClient.PutAsJsonAsync($"api/Teacher?teacherId={teacherId}", teacherDto);
        }
    }
}
