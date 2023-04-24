using System;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos.Lot
{
    public class UpdateLotDTO
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        [Range(1, 150)]
        public int Quantity { get; set; }
        public int EventId { get; set; }
        public bool Status { get; set; }
    }
}

