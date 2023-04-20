using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Dtos.Event;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IGeneralRepository generalRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<ReadEventDTO[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            var events = await _eventRepository.GetAllEventsAsync(includeSpeakers);

            if (events is null) return null;

            return _mapper.Map<ReadEventDTO[]>(events);
        }

        public async Task<ReadEventDTO[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            var events = await _eventRepository.GetAllEventsByThemeAsync(theme, includeSpeakers);

            if (events is null) return null;

            return _mapper.Map<ReadEventDTO[]>(events);
        }

        public async Task<ReadEventDTO> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            var @event = await _eventRepository.GetEventByIdAsync(eventId, includeSpeakers);

            if (@event is null) return null;

            return _mapper.Map<ReadEventDTO>(@event);
        }

        public async Task<ReadEventDTO> AddEvent(CreateEventDTO eventDTO)
        {
            var eventPersist = _mapper.Map<Event>(eventDTO);

            _generalRepository.Add<Event>(eventPersist);

            if (!await _generalRepository.SaveChangesAsync()) return null;

            return _mapper.Map<ReadEventDTO>(eventPersist);
        }

        public async Task<ReadEventDTO> UpdateEvent(int eventId, UpdateEventDTO eventDTO)
        {
            var eventExists = await _eventRepository.GetEventByIdAsync(eventId, false);

            if (eventExists is null) return null;

            _mapper.Map(eventDTO, eventExists);
            _generalRepository.Update<Event>(eventExists);

            if (!await _generalRepository.SaveChangesAsync()) return null;

            return _mapper.Map<ReadEventDTO>(eventExists);
        }

        public async Task<ReadEventDTO> DeleteEvent(int eventId)
        {
            var eventExists = await _eventRepository.GetEventByIdAsync(eventId, false);

            if (eventExists is null) return null;

            await _eventRepository.DeleteEventById(eventExists.Id);

            return _mapper.Map<ReadEventDTO>(eventExists);
        }
    }
}