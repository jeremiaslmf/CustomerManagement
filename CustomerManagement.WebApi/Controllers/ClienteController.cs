using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : AbstractController
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
        [Route("exlcuir")]
        public IActionResult Exlcuir([FromBody] ClienteDTO.Excluir dto)
        {
            _clienteService.Exlcuir(dto);
            return Ok();
        }

        [HttpGet]
        [Route("obterporid")]
        public IActionResult ObterPorId([FromBody] ClienteDTO.ObterPorId dto)
        {
            return Ok(_clienteService.ObterPorId(dto.Id));
        }
    }
}
