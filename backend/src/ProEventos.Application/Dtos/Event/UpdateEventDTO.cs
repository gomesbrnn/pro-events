using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos.Event
{
    public class UpdateEventDTO
    {
        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Theme { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int AmountPeople { get; set; }

        public string ImageURL { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<int> LotsId { get; set; }
        public IEnumerable<int> SocialMediaId { get; set; }
        public IEnumerable<int> SpeakersId { get; set; }
        public bool Status { get; set; }
    }
}