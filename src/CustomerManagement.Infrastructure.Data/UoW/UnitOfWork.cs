using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;
using CustomerManagement.Infrastructure.Data.Repositories;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMContext _context;

        private ClienteRepository _clienteRepository;
        private EnderecoRepository _enderecoRepository;

        public UnitOfWork(CMContext context)
        {
            _context = context;
        }

        public IClienteRepository ClienteRepository
        { get => _clienteRepository ??= new ClienteRepository(_context); }
        
        public IEnderecoRepository EnderecoRepository
        { get => _enderecoRepository ??= new EnderecoRepository(_context); }

        public bool SaveChanges() => _context.SaveChanges() > 0;

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public void Dispose() => _context.Dispose();
    }
}
