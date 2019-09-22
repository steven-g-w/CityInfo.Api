using CityInfo.Api.Common;
using CityInfo.Modules.ParentalFacilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CityInfo.Api.DependencyInjection
{
    public static class ModuleRegistry
    {
        public static readonly IReadOnlyCollection<IModule> Modules;

        static ModuleRegistry()
        {
            Modules = new ReadOnlyCollection<IModule>(new List<IModule>
            {
                new ParentalFacilitiesModule()
            });
        }
    }
}
