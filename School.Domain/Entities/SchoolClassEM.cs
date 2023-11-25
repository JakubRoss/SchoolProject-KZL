namespace School.Domain.Entities
{
    public class SchoolClassEM
    {
        public int Id { get; set; }
        public string ClassName { get; set; } = default!;

        //EF NAVIGATION
        public List<StudentEM>? Students { get; set; } = new List<StudentEM>();
        public List<TeacherEM>? Teachers { get; set; } = new List<TeacherEM>();
    }
}
