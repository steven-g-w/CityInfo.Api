using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.Api.DependencyInjection
{
    public static class ResourceAccessExtensions
    {
        public static void AddResourceAccess(this IServiceCollection services, IHostingEnvironment environment)
        {
            AddModules(services, environment);
        }

        private static void AddModules(IServiceCollection services, IHostingEnvironment environment)
        {
            foreach (var module in ModuleRegistry.Modules)
            {
                module.AddResourceAccess(services, environment);
            }
        }
    }
}
