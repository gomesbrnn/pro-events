using AutoMapper;
using ProEventos.Application.Dtos.Lot;
using ProEventos.Domain.Models;

namespace ProEventos.Application.Mappings
{
    public class LotMapping : Profile
    {
        public LotMapping()
        {
            CreateMap<Lot, CreateLotDTO>().ReverseMap();
            CreateMap<Lot, ReadLotDTO>().ReverseMap();
            CreateMap<Lot, UpdateLotDTO>().ReverseMap();
        }
    }
}