using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("gravar")]
        public IActionResult Gravar([FromBody] ClienteDTO.Gravar dto)
        {
            if (!_clienteService.Gravar(dto))
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("excluir")]
        public IActionResult Exlcuir([FromBody] ClienteDTO.Excluir dto)
        {
            _clienteService.Exlcuir(dto);
            return Ok();
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult ObterPorId([FromRoute] ClienteDTO.ObterPorId dto)
        {
            return Ok(_clienteService.ObterPorId(dto.Id));
        }
    }
}
