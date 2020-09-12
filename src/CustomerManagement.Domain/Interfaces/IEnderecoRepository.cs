using CustomerManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Domain.Interfaces
{
    public interface IEnderecoRepository : IGenericRepository<Endereco>
    {
        ICollection<Endereco> GetAllByClienteId(Guid id);
    }
}
