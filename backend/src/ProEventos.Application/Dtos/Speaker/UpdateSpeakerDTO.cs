using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos.Speaker
{
    public class UpdateSpeakerDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string PersonalResume { get; set; }

        [RegularExpression(@"/.*\.(gif|jpe?g|bmp|png)$/igm")]
        public string ImageURL { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<int> SocialMediaId { get; set; }
        public IEnumerable<int> EventsId { get; set; }
        public bool Status { get; set; }
    }
}