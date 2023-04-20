using System.Collections.Generic;
using ProEventos.Application.Dtos.Lot;
using ProEventos.Application.Dtos.SocialMedia;
using ProEventos.Application.Dtos.Speaker;

namespace ProEventos.Application.Dtos.Event
{
    public class ReadEventDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public int AmountPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<CreateLotDTO> Lots { get; set; }
        public IEnumerable<CreateSocialMediaDTO> SocialMedia { get; set; }
        public IEnumerable<CreateSpeakerDTO> Speakers { get; set; }
        public bool Status { get; set; }

    }
}