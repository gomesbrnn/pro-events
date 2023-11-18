using AutoMapper;
using ProEventos.Application.Dtos.Speaker;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Mappings
{
    public class SpeakerMapping : Profile
    {
        public SpeakerMapping()
        {
            CreateMap<Speaker, CreateSpeakerDTO>().ReverseMap();
            CreateMap<Speaker, ReadSpeakerDTO>().ReverseMap();
            CreateMap<Speaker, UpdateSpeakerDTO>().ReverseMap();
        }

    }
}