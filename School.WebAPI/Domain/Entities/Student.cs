namespace School.WebAPI.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float GradeAvarage { get; set; }
        public Guid CalssId { get; set; }

    }
    
}
