using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos.SocialMedia
{
    public class UpdateSocialMediaDTO
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string URL { get; set; }

        public int EventId { get; set; }
        public int SpeakerId { get; set; }
        public bool Status { get; set; }
    }
}