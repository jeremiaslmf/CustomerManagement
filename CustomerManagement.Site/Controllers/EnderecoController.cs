using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        [Route("gravar")]
        public IActionResult Gravar([FromBody] EnderecoDTO.Gravar dto)
        {
            if (!_enderecoService.Gravar(dto))
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("excluir")]
        public IActionResult Exlcuir([FromBody] EnderecoDTO.Excluir dto)
        {
            _enderecoService.Exlcuir(dto);
            return Ok();
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult ObterPorId([FromRoute] EnderecoDTO.ObterPorId dto)
        {
            return Ok(_enderecoService.GetById(dto.Id));
        }

        [HttpGet]
        [Route("obterTodosPorClienteId/{Id}")]
        public IActionResult ObterTodosPorClienteId([FromRoute] EnderecoDTO.ObterPorId dto)
        {
            return Ok(_enderecoService.GetAllByClienteId(dto.Id));
        }
    }
}
