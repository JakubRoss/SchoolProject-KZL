﻿using AutoMapper;
using School.WebAPI.Domain.Entities;

namespace School.Application.Model
{
    public class SchoolMappingProfile : Profile
    {
        public SchoolMappingProfile()
        {
            CreateMap<StudentDto,Student>().ReverseMap();
        }
    }
}
