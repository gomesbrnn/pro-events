using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        public void Add<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteRange<T>(T[] Entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}