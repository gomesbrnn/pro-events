using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        /// <summary>
        /// GERAL
        /// </summary>
        public void Add<T>(T Entity) where T : class;
        public void Update<T>(T Entity) where T : class;
        public void Delete<T>(T Entity) where T : class;
        public void DeleteRange<T>(T[] Entity) where T : class;
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// EVENTOS
        /// </summary>
        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        public Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);

        /// <summary>
        /// PALESTRANTES
        /// </summary>
        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        public Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos);
    }
}