using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ProEventosContext _context;

        public EventoRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                       .Include(e => e.Lotes)
                                                       .Include(e => e.RedesSociais)
                                                       .OrderBy(e => e.Id);

            if (includePalestrantes is true)
            {
                query = query
                             .Include(e => e.PalestrantesEventos)
                             .ThenInclude(pe => pe.Palestrante);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                        .Include(e => e.Lotes)
                                                        .Include(e => e.RedesSociais)
                                                        .Where(e => e.Tema.ToLower() == tema.ToLower())
                                                        .OrderBy(e => e.Id);

            if (includePalestrantes is true)
            {
                query = query
                             .Include(e => e.PalestrantesEventos)
                             .ThenInclude(pe => pe.Palestrante);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                        .Include(e => e.Lotes)
                                                        .Include(e => e.RedesSociais)
                                                        .Where(e => e.Id == EventoId)
                                                        .OrderBy(e => e.Id);

            if (includePalestrantes is true)
            {
                query = query
                             .Include(e => e.PalestrantesEventos)
                             .ThenInclude(pe => pe.Palestrante);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento> DeleteEventoById(int EventoId, bool includePalestrantes = false)
        {
            Evento evento = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == EventoId);

            if (evento is not null) evento.Status = false;

            return evento;
        }
    }
}