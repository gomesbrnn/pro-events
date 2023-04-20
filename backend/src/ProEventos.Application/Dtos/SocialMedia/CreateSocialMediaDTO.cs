using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos.SocialMedia
{
    public class CreateSocialMediaDTO
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public int? EventId { get; set; }
        public int? SpeakerId { get; set; }
    }
}