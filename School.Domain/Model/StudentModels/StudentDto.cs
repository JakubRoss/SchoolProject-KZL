namespace School.Domain.Model.StudentModels
{
    public class StudentDto
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
    }
}
