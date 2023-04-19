using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.API.Dtos.Event;
using ProEventos.Domain.Models;

namespace ProEventos.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, ReadEventDTO>().ReverseMap();
        }
    }
}