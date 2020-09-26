using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CustomerManagement.Infrastructure.Data.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CMContext context) : base(context) { }

        public Cliente ObterClienteComEnderecoPorId(Guid id)
        {
            var cliente = DbSet
                .Include(x => x.Enderecos)
                .FirstOrDefault(x => x.Id == id);
            return cliente;
        }
    }
}
