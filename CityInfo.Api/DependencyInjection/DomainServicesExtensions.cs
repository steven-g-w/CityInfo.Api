using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.Api.DependencyInjection
{
    public static class DomainServicesExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            AddModules(services);
        }

        private static void AddModules(IServiceCollection services)
        {
            foreach (var module in ModuleRegistry.Modules)
            {
                module.AddDomainServices(services);
            }
        }
    }
}
