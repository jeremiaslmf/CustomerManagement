using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var retorno = _clienteService.Gravar(dto);
            if (Guid.Empty.Equals(retorno.Id))
                return BadRequest();

            return Ok(retorno);
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
            var retorno = _clienteService.GetById(dto.Id);
            if (Guid.Empty.Equals(retorno.Id))
                return BadRequest();
            return Ok(retorno);
        }

        [HttpGet]
        [Route("obterTodos")]
        public IActionResult ObterTodos()
        {
            var retorno = _clienteService.GetAll();
            if (retorno.Count == 0)
                return BadRequest();
            return Ok(retorno);
        }
    }
}
