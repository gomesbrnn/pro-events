using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos.Speaker
{
    public class CreateSpeakerDTO
    {
        public string Name { get; set; }
        public string PersonalResume { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> SocialMediaId { get; set; }
        public IEnumerable<int> EventsId { get; set; }
    }
}