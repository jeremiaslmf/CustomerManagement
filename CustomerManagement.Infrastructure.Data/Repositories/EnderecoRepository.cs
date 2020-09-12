using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Infrastructure.Data.Context;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CustomerManagement.Infrastructure.Data.Repositories
{
    public class EnderecoRepository : GenericRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CMContext context) : base(context) { }

        public ICollection<Endereco> GetAllByClienteId(Guid id)
        {
            return Context.Enderecos.Where(x => x.ClienteId.Equals(id)).ToList();
        }
    }
}
