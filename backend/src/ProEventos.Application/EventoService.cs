using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        IGeralRepository _geralRepository;
        IEventoRepository _eventoRepository;
        public EventoService(IGeralRepository geralRepository, IEventoRepository eventoRepository)
        {
            _geralRepository = geralRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralRepository.Add<Evento>(model);

                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        public Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            throw new NotImplementedException();
        }
        public Task<Evento> DeleteEvento(int eventoId)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            throw new NotImplementedException();
        }
    }
}