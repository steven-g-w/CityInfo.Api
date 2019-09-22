using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.Api.Common
{
    public interface IModule
    {
        void AddDomainServices(IServiceCollection services);
        void AddResourceAccess(IServiceCollection services, IHostingEnvironment environment);
    }
}
