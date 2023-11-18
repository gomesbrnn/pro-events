using AutoMapper;
using ProEventos.Application.Dtos.SocialMedia;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Mappings
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, CreateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, ReadSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();
        }
    }
}