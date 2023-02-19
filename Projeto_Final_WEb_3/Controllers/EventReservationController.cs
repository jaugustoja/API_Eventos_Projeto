using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Final_Web_3.Service.Dto;
using Projeto_Final_Web_3.Service.Interface;

namespace Projeto_Final_WEb_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        public IEventReservationService _EventReservationService;

        public EventReservationController(IEventReservationService CityEventService)
        {
            _EventReservationService = CityEventService;
        }

        [HttpPost("EventReservation/Inserir")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Inserir(EventReservationDto eventReservation)
        {
            if (!await _EventReservationService.Inserir(eventReservation) == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(ConsultaPersonTitle), eventReservation);
           
        }
        [HttpPatch("EventReservation/Atualizar")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarQuantidade(int numero, long idReservation)
        {
            if (!await _EventReservationService.EditarQuantidade(numero, idReservation))
            {
                return BadRequest();
            }

            return NoContent();
            
        }
        [HttpGet("EventReservation/Consulta")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EventReservationDto>>> ConsultaPersonTitle(string nome, string tituloEvento)
        {

            return Ok(await _EventReservationService.ConsultaPersonTitle(nome, tituloEvento));
        }
        [HttpDelete("EventReservation/Deletar")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarReserva(long idReservation)
        {
            if (_EventReservationService.DeletarReserva(idReservation) == null)
            {
                return BadRequest();
            }
            return Ok(_EventReservationService.DeletarReserva(idReservation));
        }
    }
}