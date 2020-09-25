using System.Threading.Tasks;

namespace CustomerManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IClienteRepository ClienteRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
