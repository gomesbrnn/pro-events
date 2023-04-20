using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos.Event
{
    public class UpdateEventDTO
    {
        public string City { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public int AmountPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> LotsId { get; set; }
        public IEnumerable<int> SocialMediaId { get; set; }
        public IEnumerable<int> SpeakersId { get; set; }
        public bool Status { get; set; }
    }
}