using School.Domain.Entities;
using School.Domain.Model.TeacherModels;

namespace School.WebUI.Services.TeracherService
{
    public class TeacherService : ITeacherService
    {
        private HttpClient _httpClient;

        public TeacherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<TeacherEM> Teachers { get; set; } = new List<TeacherEM>();
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
            var students = await _httpClient.GetFromJsonAsync<List<TeacherEM>>("api/Teacher/all");
            if (students != null)
                Teachers = students;
        }

        public async Task<TeacherEM> ReadAsync(string teacherId)
        {
            var result = await _httpClient.GetAsync($"api/Teacher?teacherId={teacherId}");
            var teacherN= new TeacherEM();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var teacherQ= await result.Content.ReadFromJsonAsync<TeacherEM>();
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
