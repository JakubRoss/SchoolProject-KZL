using System.Text.Json.Serialization;

namespace School.WebAPI.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public float? GradeAvarage { get; set; }

        //EF NAVIGATION
        public int? SchoolClassId { get; set; }
        [JsonIgnore]
        public SchoolClass SchoolClass { get; set; } = default!;

    }
    
}
