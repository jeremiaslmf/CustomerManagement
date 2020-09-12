using CustomerManagement.Domain.Interfaces;

namespace CustomerManagement.Application.Services
{
    public abstract class GenericService
    {
        internal IUnitOfWork UnitOfWork { get; set; }

        protected GenericService(IUnitOfWork iuow)
        {
            UnitOfWork = iuow;
        }
    }
}
