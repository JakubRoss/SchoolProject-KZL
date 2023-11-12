using System.Text.Json.Serialization;

namespace School.WebAPI.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float? Post { get; set; }
        public DateTime? StartOfWork { get; set; }

        //EF NAVIGATION
        [JsonIgnore]
        public List<SchoolClass>? SchoolClasses { get; set; } = new List<SchoolClass>();

    }
}
