namespace AMXCurrentAccount.Core.Application.Ioc
{
    using AMXCurrentAccount.Core.Application.CurrentAccount.Services;
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentAccountService, CurrentAccountService>();

            return services;
        }
    }
}
