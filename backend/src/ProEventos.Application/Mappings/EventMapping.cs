using AutoMapper;
using ProEventos.Application.Dtos.Event;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Mappings
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<Event, CreateEventDTO>().ReverseMap();
            CreateMap<Event, ReadEventDTO>().ReverseMap();
            CreateMap<Event, UpdateEventDTO>().ReverseMap();
        }
    }
}