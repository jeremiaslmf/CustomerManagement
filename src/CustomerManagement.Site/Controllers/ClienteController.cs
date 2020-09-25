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
        public IActionResult Create([FromBody] ClienteDTO.Gravar dto)
        {
            var retorno = _clienteService.Criar(dto);
            if (Guid.Empty.Equals(retorno.Id))
                return BadRequest();

            return CreatedAtRoute("Get", new { Id = retorno.Id }, retorno);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] ClienteDTO.Gravar dto)
        {
            if (Guid.Empty.Equals(id))
                return BadRequest();

            if (!_clienteService.IsClienteExists(dto.Id))
                return NotFound();
            
            _clienteService.Atualizar(dto);

            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete([FromRoute] ClienteDTO.Excluir dto)
        {
            if (!_clienteService.IsClienteExists(dto.Id))
                return NotFound();

            _clienteService.Exlcuir(dto);
            return NoContent();
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get([FromRoute] ClienteDTO.ObterPorId dto)
        {
            var retorno = _clienteService.GetById(dto.Id);
            if (Guid.Empty.Equals(retorno.Id))
                return NotFound();
            return Ok(retorno);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var retorno = _clienteService.GetAll();
            if (retorno.Count == 0)
                return NotFound();
            return Ok(retorno);
        }
    }
}
