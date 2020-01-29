using AutoMapper;
using CodingChallenge.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Project, ProjectViewModel>().ReverseMap();
        }
    }
}
