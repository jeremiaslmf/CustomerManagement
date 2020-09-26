using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create([FromBody] ClienteDTO.Gravar dto)
        {
            var retorno = await _clienteService.Criar(dto);
            if (Guid.Empty.Equals(retorno.Id))
                return BadRequest();

            dto.Id = retorno.Id;
            dto.Endereco.ClienteId = retorno.Id;
            return CreatedAtRoute("", new { retorno.Id }, dto);
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteDTO.Gravar dto)
        {
            if (!dto.Id.Equals(id) || Guid.Empty.Equals(id))
                return BadRequest();

            if (!_clienteService.IsClienteExists(dto.Id))
                return NotFound();

            try
            {
                await _clienteService.Atualizar(dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] ClienteDTO.Excluir dto)
        {
            if (!_clienteService.IsClienteExists(dto.Id))
                return NotFound();

            await _clienteService.Exlcuir(dto);
            return NoContent();
        }

        //[HttpGet (Name = "Get")]
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<ClienteDTO.Retorno> Get([FromRoute] ClienteDTO.ObterPorId dto)
        {
            var retorno = _clienteService.GetById(dto.Id);
            if (Guid.Empty.Equals(retorno.Id))
                return NotFound();
            return retorno;
        }

        [HttpGet]
        public ActionResult<List<ClienteDTO.Retorno>> Get()
        {
            var retorno = _clienteService.GetAll();
            if (retorno.Count == 0)
                return NotFound();
            return retorno;
        }
    }
}
