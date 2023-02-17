using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly ProEventosContext _context;

        public PalestranteRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                                                 .Include(p => p.RedesSociais)
                                                                 .OrderBy(p => p.Id);

            if (includeEventos is true)
            {
                query = query
                             .Include(p => p.PalestranteEventos)
                             .ThenInclude(pe => pe.Evento);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                                                 .Include(p => p.RedesSociais)
                                                                 .Where(p => p.Nome.ToLower() == nome.ToLower())
                                                                 .OrderBy(p => p.Id);

            if (includeEventos is true)
            {
                query = query
                             .Include(p => p.PalestranteEventos)
                             .ThenInclude(pe => pe.Evento);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                                                 .Include(p => p.RedesSociais)
                                                                 .Where(p => p.Id == PalestranteId)
                                                                 .OrderBy(p => p.Id);

            if (includeEventos is true)
            {
                query = query
                             .Include(p => p.PalestranteEventos)
                             .ThenInclude(pe => pe.Evento);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}