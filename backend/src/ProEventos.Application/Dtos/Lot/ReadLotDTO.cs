using ProEventos.Application.Dtos.Event;

namespace ProEventos.Application.Dtos.Lot
{
    public class ReadLotDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Quantity { get; set; }
        public CreateEventDTO Event { get; set; }
        public bool Status { get; set; }
    }
}