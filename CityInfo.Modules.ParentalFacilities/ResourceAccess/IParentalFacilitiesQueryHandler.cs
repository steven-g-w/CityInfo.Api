using CityInfo.Modules.ParentalFacilities.Domain.Models;
using System.Collections.Generic;

namespace CityInfo.Modules.ParentalFacilities.ResourceAccess
{
    public interface IParentalFacilitiesQueryHandler
    {
        IEnumerable<ParentalFacility> Query(ListParentalFacilitiesQuery query);
    }
}
