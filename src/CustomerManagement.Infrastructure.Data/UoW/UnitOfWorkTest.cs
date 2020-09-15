using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;
using CustomerManagement.Infrastructure.Data.Repositories;

namespace CustomerManagement.Infrastructure.Data.Uow
{
    public class UnitOfWorkTest : IUnitOfWork
    {
        private readonly CMContext _context;

        private ClienteRepository _clienteRepository;
        private EnderecoRepository _enderecoRepository;

        public UnitOfWorkTest(CMContext context)
        {
            _context = context;
        }

        public IClienteRepository ClienteRepository
        { get => _clienteRepository ?? new ClienteRepository(_context); }
        
        public IEnderecoRepository EnderecoRepository
        { get => _enderecoRepository ?? new EnderecoRepository(_context); }

        public bool SaveChanges() => _context.SaveChanges() > 0;

        public void Dispose() => _context.Dispose();
    }
}
