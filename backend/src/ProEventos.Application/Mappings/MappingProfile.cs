using AutoMapper;
using ProEventos.Application.Dtos.Event;
using ProEventos.Application.Dtos.Lot;
using ProEventos.Application.Dtos.SocialMedia;
using ProEventos.Application.Dtos.Speaker;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, CreateEventDTO>().ReverseMap();
            CreateMap<Event, ReadEventDTO>().ReverseMap();
            CreateMap<Event, UpdateEventDTO>().ReverseMap();

            CreateMap<Lot, CreateLotDTO>().ReverseMap();
            CreateMap<Lot, ReadLotDTO>().ReverseMap();
            CreateMap<Lot, UpdateLotDTO>().ReverseMap();

            CreateMap<SocialMedia, CreateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, ReadSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();

            CreateMap<Speaker, CreateSpeakerDTO>().ReverseMap();
            CreateMap<Speaker, ReadSpeakerDTO>().ReverseMap();
            CreateMap<Speaker, UpdateSpeakerDTO>().ReverseMap();
        }
    }
}