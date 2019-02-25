using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RrepTest.Dto;
using RrepTest.Models;

namespace RrepTest.MapperProfile
{
    public class OsobaProfile : Profile
    {
        public OsobaProfile()
        {
            CreateMap<Osoba, OsobaDto>();
            CreateMap<OsobaDto, Osoba>();//OsobaUpdateDto
            CreateMap<OsobaUpdateDto, Osoba>();//OsobaUpdateDto
            CreateMap<Osoba, OsobaUpdateDto>();//OsobaUpdateDto
        }
    }
}
