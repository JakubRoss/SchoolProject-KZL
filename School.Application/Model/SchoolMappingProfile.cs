using AutoMapper;
using School.Application.Model.SchoolClassModels;
using School.Application.Model.StudentModels;
using School.Application.Model.TeacherModels;
using School.WebAPI.Domain.Entities;

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
