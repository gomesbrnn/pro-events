using System.Collections.Generic;
using ProEventos.Application.Dtos.Event;
using ProEventos.Application.Dtos.SocialMedia;

namespace ProEventos.Application.Dtos.Speaker
{
    public class ReadSpeakerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PersonalResume { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<CreateSocialMediaDTO> SocialMedia { get; set; }
        public IEnumerable<CreateEventDTO> Events { get; set; }
        public bool Status { get; set; }
    }
}