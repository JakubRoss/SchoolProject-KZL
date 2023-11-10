namespace School.WebAPI.Application.Model.Studentmodels
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float GradeAvarage { get; set; }
        public string CalssId { get; set; }
    }
}
