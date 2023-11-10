namespace School.WebAPI.Application.Model.StudentModels
{
    public class UpdateStudentDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float GradeAvarage { get; set; }
        public string CalssId { get; set; }
    }
}
