using Projeto_Final_Web_3.Service.Dto;
using Projeto_Final_Web_3.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Final_WEb_3.Filter;

namespace Projeto_Final_WEb_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(ExceçãoGeralFilter))]
    public class CityEventController : ControllerBase
    {
        public ICityEventService _CityEventService;

        public CityEventController(ICityEventService CityEventService)
        {
            _CityEventService = CityEventService;
        }

        [HttpPost("CityEvent/Inserir")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Inserir(CityEventDto cityEvent)
        {
            if (!await _CityEventService.Inserir(cityEvent))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Consultar), cityEvent);
            
        }
        [HttpGet("Consultar/Titulo")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Consultar(string nome)
        {
            return Ok(_CityEventService.Consultar(nome));

        }
        [HttpGet("Consultar/Local/Data")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultarLocalData(string local, DateTime data)
        {

            return Ok(_CityEventService.ConsultarLocalData(local, data));

        }
        
        [HttpGet("Consultar/Preco/Data")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultaPrecoData(decimal minPrice, decimal maxPrice, DateTime data)
        {

            return Ok(_CityEventService.ConsultaPrecoData(minPrice, maxPrice, data));

        }
        [HttpPut("CityEvent/Atualizar")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarEvento(CityEventDto cityevent, int id)
        {
            if (!await _CityEventService.AtualizarEvento(cityevent, id))
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("CityEvent/Deletar")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletarEvento(int id)
        {
            if (await _CityEventService.DeletarEvento(id) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}