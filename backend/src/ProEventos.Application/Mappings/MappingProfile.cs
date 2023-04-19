using AutoMapper;
using ProEventos.Application.Dtos.Event;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, ReadEventDTO>().ReverseMap();
        }
    }
}