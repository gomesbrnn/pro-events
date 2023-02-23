using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/v1/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);

                if (eventos is null) return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    titulo = "Não foi possivel tratar sua solicitação",
                    status = 500,
                    detalhes = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);

                if (evento is null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    titulo = "Não foi possivel tratar sua solicitação",
                    status = 500,
                    detalhes = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }

        [HttpGet("{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);

                if (evento is null) return NoContent();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    titulo = "Não foi possivel tratar sua solicitação",
                    status = 500,
                    detalhes = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }
    }
}