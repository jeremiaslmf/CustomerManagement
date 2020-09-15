﻿using CustomerManagement.Application.DTOs;
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
            if (string.IsNullOrEmpty(retorno.ToString()))
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
            return Ok(_clienteService.GetById(dto.Id));
        }

        [HttpGet]
        [Route("obterTodos")]
        public IActionResult ObterTodos()
        {
            return Ok(_clienteService.GetAll());
        }
    }
}
