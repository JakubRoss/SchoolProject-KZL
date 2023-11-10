using AutoMapper;
using School.WebAPI.Application.Model;
using School.WebAPI.Domain.Entities;
using System.Data;

namespace School.WebAPI.Application
{
    public class SchoolMappingProfile : Profile
    {
        public SchoolMappingProfile()
        {
            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
            CreateMap<DataRow, ReadTeacherDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["Name"]))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src["Surname"]))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src["Post"]))
                .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src["StartOfWork"]));
            CreateMap<DataRow, TeacherDto>()
                .ForMember(dest=>dest.Id, opt => opt.MapFrom(src => src["Id"]))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["Name"]))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src["Surname"]))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src["Post"]))
                .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src["StartOfWork"]));

        }
    }
}
