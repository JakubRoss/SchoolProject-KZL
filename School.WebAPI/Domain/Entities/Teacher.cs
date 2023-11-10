namespace School.WebAPI.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public float? Post { get; set; }
        public DateTime StartOfWork { get; set; }

    }
}
