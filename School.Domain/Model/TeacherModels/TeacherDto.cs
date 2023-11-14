namespace School.Domain.Model.TeacherModels
{
    public class TeacherDto
    {
        public string Name { get; set; } =string.Empty;
        public string Surname { get; set; } = string.Empty;
        public float? Post { get; set; }
        public DateTime? StartOfWork { get; set; }
    }
}
