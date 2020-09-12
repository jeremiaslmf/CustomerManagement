using CustomerManagement.Application.Interfaces;
using CustomerManagement.Domain.Interfaces;

namespace CustomerManagement.Application.Services
{
    public class EnderecoService : GenericService, IEnderecoService
    {
        public EnderecoService(IUnitOfWork iuow) : base(iuow)
        {
        }
    }
}
