using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos.SocialMedia
{
    public class CreateSocialMediaDTO
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string URL { get; set; }

        public int? EventId { get; set; }
        public int? SpeakerId { get; set; }
    }
}