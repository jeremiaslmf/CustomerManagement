using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;

namespace CustomerManagement.Infrastructure.Data.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CMContext context) : base(context)
        {
        }
    }
}
