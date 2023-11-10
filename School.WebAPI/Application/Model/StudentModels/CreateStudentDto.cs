namespace School.WebAPI.Application.Model.StudentModels
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
