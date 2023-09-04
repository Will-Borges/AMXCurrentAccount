namespace AMXCurrentAccount.Adapters.Persistence.Ioc
{
    using AMXCurrentAccount.Adapters.Persistence.CurrentAccount.Repositories;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Adapters.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class AdapterModuleExtensions
    {
        public static IServiceCollection AddPersistenceRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICurrentAccountRepository, CurrentAccountRepository>();
            services.AddScoped<ICustomerCurrentAccountRepository, CustomerCurrentAccountRepository>();
            
            return services;
        }
    }
}
