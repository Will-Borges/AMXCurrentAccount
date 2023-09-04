namespace AMXCurrentAccount.Ioc
{
    using AMXCurrentAccount.Presenters;
    using AMXCurrentAccount.Presenters.Interfaces;

    public static class PortsModuleExtensions
    {
        public static IServiceCollection AddPortsPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICurrentAccountPresenter, CurrentAccountPresenter>();

            return services;
        }
    }
}
