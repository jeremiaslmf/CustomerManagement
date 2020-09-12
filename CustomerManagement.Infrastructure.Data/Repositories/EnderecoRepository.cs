using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Infrastructure.Data.Context;

namespace CustomerManagement.Infrastructure.Data.Repositories
{
    public class EnderecoRepository : GenericRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CMContext context) : base(context)
        {
        }
    }
}
