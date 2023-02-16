using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/v1/eventos")]
    public class EventosController : ControllerBase
    {
        private ProEventosContext _context;
        public EventosController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Evento>> GetEventos()
        {
            var eventos = _context.Eventos.Where(evento => evento.Status == true).AsNoTracking().ToList();
            return StatusCode(200, eventos);
        }

        [HttpGet("{id}")]
        public ActionResult GetEventoId(int id)
        {
            var evento = _context.Eventos.FirstOrDefault(evento => evento.Id == id);
            return StatusCode(200, evento);
        }
    }
}