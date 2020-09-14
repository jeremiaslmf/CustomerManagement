using CustomerManagement.Application.DTOs;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Interfaces
{
    public interface ICepService
    {
        Task<CepDTO.Retorno> ObterCep(CepDTO.Envio dto);
    }
}
