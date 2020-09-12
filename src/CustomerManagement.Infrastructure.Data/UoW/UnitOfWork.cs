using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;

namespace CustomerManagement.Infrastructure.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CMContext _context;

        public IClienteRepository ClienteRepository { get; }
        public IEnderecoRepository EnderecoRepository { get; }

        public UnitOfWork(CMContext context,
            IClienteRepository clienteRepository,
            IEnderecoRepository enderecoRepository)
        {
            _context = context;
            ClienteRepository = clienteRepository;
            EnderecoRepository = enderecoRepository;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
