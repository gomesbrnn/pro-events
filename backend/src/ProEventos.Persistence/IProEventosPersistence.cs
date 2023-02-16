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
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityArray) where T : class;
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// EVENTOS
        /// </summary>
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);

        /// <summary>
        /// PALESTRANTES
        /// </summary>
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}