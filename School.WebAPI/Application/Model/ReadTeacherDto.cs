namespace School.WebAPI.Application.Model
{
    public class ReadTeacherDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public float? Post { get; set; }
        public DateTime StartOfWork { get; set; }
    }
}
