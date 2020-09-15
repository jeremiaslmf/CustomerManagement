using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;
using CustomerManagement.Infrastructure.Data.Repositories;
using CustomerManagement.Infrastructure.Data.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorServices
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<ICepService, CepService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<CMContext>();
            services.AddDbContext<CMTestsContext>();
        }
    }
}
