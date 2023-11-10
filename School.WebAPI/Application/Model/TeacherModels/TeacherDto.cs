using School.WebAPI.Application.Model.ClassModels;

namespace School.WebAPI.Application.Model.TeacherModels
{
    public class TeacherDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float? Post { get; set; }
        public DateTime StartOfWork { get; set; } = DateTime.Now;

    }
}
