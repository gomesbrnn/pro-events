using System.Threading.Tasks;
using ProEventos.Application.Dtos.Event;

namespace ProEventos.Application.Interfaces
{
    public interface IEventService
    {
        Task<ReadEventDTO[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<ReadEventDTO[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<ReadEventDTO> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
        Task<ReadEventDTO> AddEvent(CreateEventDTO eventDTO);
        Task<ReadEventDTO> UpdateEvent(int eventId, UpdateEventDTO eventDTO);
        Task<ReadEventDTO> DeleteEvent(int eventId);
    }
}