using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;
using CustomerManagement.Infrastructure.Data.Repositories;
using CustomerManagement.Infrastructure.Data.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorDependencies
    {
        public static void ResolveDependencies(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterRepositories(services);
            RegisterContexts(services);
        }

        private static void RegisterContexts(IServiceCollection services)
        {
            services.AddDbContext<CMContext>();
            services.AddDbContext<CMTestsContext>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<ICepService, CepService>();
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
