using System.Text.Json.Serialization;

namespace School.Domain.Entities
{
    public class StudentEM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public float? GradeAvarage { get; set; }

        public int? SchoolClassId { get; set; }


    }

}
