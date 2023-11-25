using System.Text.Json.Serialization;

namespace School.Domain.Entities
{
    public class TeacherEM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public float? Post { get; set; }
        public DateTime? StartOfWork { get; set; }

    }
}
