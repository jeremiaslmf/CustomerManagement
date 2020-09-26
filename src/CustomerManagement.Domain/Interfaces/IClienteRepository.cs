using CustomerManagement.Domain.Entities;
using System;

namespace CustomerManagement.Domain.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Cliente ObterClienteComEnderecoPorId(Guid id);
    }
}
