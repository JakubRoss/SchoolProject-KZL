using School.Domain.Entities;
using System.Net.Http.Json;

namespace School.DesktopUI
{
    public  class SchoolService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public async Task<List<SchoolClassEM>> SendGetRequest()
        {
            string apiUrl = "https://localhost:7225/api/Class/all";
            var notEmptyBody = new List<SchoolClassEM>() {
                        new SchoolClassEM() {
                            ClassName = "Nie ma klas",
                            Id = 0,
                            Students = new List<StudentEM>(),
                            Teachers = new List<TeacherEM>()
                        }
                    };
            try
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<List<SchoolClassEM>>();
                    if (responseBody == null)
                        return notEmptyBody;
                    return responseBody;
                }
                else
                {
                    return notEmptyBody;
                }
            }
            catch (HttpRequestException ex)
            {
                return notEmptyBody;
            }
        }

    }
}
