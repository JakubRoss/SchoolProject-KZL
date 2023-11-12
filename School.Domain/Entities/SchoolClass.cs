namespace School.WebAPI.Domain.Entities
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string ClassName { get; set; } = default!;

        //EF NAVIGATION
        public List<Student>? Students { get; set; } = new List<Student>();
        public List<Teacher>? Teachers { get; set; } = new List<Teacher>();
    }
}
