using AutoMapper;
using School.Domain.Model.SchoolClassModels;
using School.Domain.Model.StudentModels;
using School.Domain.Model.TeacherModels;
using School.Infrastructure.Entities;

namespace School.Application.Model
{
    public class SchoolMappingProfile : Profile
    {
        public SchoolMappingProfile()
        {
            CreateMap<StudentDto,Student>().ReverseMap();
            CreateMap<TeacherDto,Teacher>().ReverseMap();
            CreateMap<SchoolClassDto,SchoolClass>().ReverseMap();
        }
    }
}
