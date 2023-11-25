using School.Domain.Entities;
using School.Domain.Model.StudentModels;

namespace School.WebUI.Services.StudentService
{
    public class StudentsService : IStudentsService
    {
        private HttpClient _httpClient;

        public StudentsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
         }

        public List<StudentEM> Students { get; set; } = new List<StudentEM>();
        public StudentDto StudentDto { get; set; } = new StudentDto();
        public StudentEM student { get; set; } = new StudentEM();

        public async Task CreateAsync()
        {
            await _httpClient.PostAsJsonAsync("/api/Student", StudentDto);
        }

        public async Task DeleteAsync(string studentId)
        {
            await _httpClient.DeleteAsync($"/api/Student?studentId={studentId}");
        }

        public async Task ReadAllAsync()
        {
            var students = await _httpClient.GetFromJsonAsync<List<StudentEM>>("api/student/all");
            if(students != null)
                Students = students;
        }

        public async Task<StudentEM> ReadAsync(string studentId)
        {
            var result = await _httpClient.GetAsync($"api/Student?studentId={studentId}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<StudentEM>();
            }
            return null;
        }

        public async Task<List<StudentByPhraseDto>> SearchBy(string phrase)
        {
            var result = await _httpClient.GetAsync($"api/Student/{phrase}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                 return await result.Content.ReadFromJsonAsync<List<StudentByPhraseDto>>();
            }
            return new List<StudentByPhraseDto>();
        }

        public async Task UpdateAsync(StudentDto studentDto, string studentId)
        {
            await _httpClient.PutAsJsonAsync($"api/Student?studentId={studentId}", studentDto);
        }
    }
}
