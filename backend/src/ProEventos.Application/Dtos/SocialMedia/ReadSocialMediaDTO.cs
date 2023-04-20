using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Dtos.Event;
using ProEventos.Application.Dtos.Speaker;

namespace ProEventos.Application.Dtos.SocialMedia
{
    public class ReadSocialMediaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public CreateEventDTO Event { get; set; }
        public CreateSpeakerDTO Speaker { get; set; }
        public bool Status { get; set; }
    }
}