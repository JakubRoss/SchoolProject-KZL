﻿namespace School.Domain.Model.TeacherModels
{
    public class TeacherDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float? Post { get; set; }
        public DateTime? StartOfWork { get; set; }
    }
}