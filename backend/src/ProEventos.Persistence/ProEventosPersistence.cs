using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;

        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class

        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
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