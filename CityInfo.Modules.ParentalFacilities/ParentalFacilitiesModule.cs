using CityInfo.Api.Common;
using CityInfo.Modules.ParentalFacilities.Api.Mappers;
using CityInfo.Modules.ParentalFacilities.ResourceAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.Modules.ParentalFacilities
{
    public class ParentalFacilitiesModule : IModule
    {
        public void AddDomainServices(IServiceCollection services)
        {
            services.AddScoped<IParentalFacilityMapper, ParentalFacilityMapper>();
            services.AddScoped<ISearchParentalFacilitiesMapper, SearchParentalFacilitiesMapper>();
        }

        public void AddResourceAccess(IServiceCollection services, IHostingEnvironment environment)
        {
            services.AddSingleton<IParentalFacilitiesQueryHandler, LocalParentalFacilitiesQueryHandler>();
        }
    }
}
