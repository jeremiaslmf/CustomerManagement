using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerManagement.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet]
        [Route("{Cep}")]
        public async Task<CepDTO.Retorno> ObterCep([FromRoute] CepDTO.Envio dto)
        {
            return await _cepService.ObterCep(dto);
        }
    }
}
