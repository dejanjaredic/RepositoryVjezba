using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RrepTest.Dto;
using RrepTest.Models;

namespace RrepTest.MapperProfile
{
    public class KoriscenjeUredjajaDto : Profile
    {
        public KoriscenjeUredjajaDto()
        {
            CreateMap<KoriscenjeUredjaja, KoriscenjeUredjajaDto>();
            CreateMap<KoriscenjeUredjajaDto, KoriscenjeUredjaja>();
            
            
        }
    }
}
