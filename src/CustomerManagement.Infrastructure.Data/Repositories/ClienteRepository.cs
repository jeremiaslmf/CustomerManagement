using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Infrastructure.Data.Context;
using System.Configuration;

namespace CustomerManagement.Infrastructure.Data.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CMContext context) : base(context)
        {
        }
    }
}
