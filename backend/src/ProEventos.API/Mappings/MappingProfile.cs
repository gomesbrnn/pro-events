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