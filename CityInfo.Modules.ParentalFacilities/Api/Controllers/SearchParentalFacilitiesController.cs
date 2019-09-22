using CityInfo.Api.DataContracts;
using CityInfo.Api.DataContracts.ParentalFacilities;
using CityInfo.Modules.ParentalFacilities.ResourceAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CityInfo.Modules.ParentalFacilities.Api.Mappers;
using CityInfo.Modules.ParentalFacilities.Domain.Models;

namespace CityInfo.Modules.ParentalFacilities.Api.Controllers
{
    public class SearchParentalFacilitiesController : ControllerBase
    {
        private readonly IParentalFacilitiesQueryHandler _queryHandler;
        private readonly IParentalFacilityMapper _outputMapper;

        public SearchParentalFacilitiesController(IParentalFacilitiesQueryHandler queryHandler, 
            IParentalFacilityMapper outputMapper)
        {
            _queryHandler = queryHandler;
            _outputMapper = outputMapper;
        }

        [HttpGet(Resources.ParentalFacilities)]
        public IEnumerable<ParentalFacilityDto> Invoke(string key)
        {
            var entities = _queryHandler.Query(new ListParentalFacilitiesQuery
            {
                KeyWord = key
            });

            return entities.Select(_outputMapper.Map);
        }
    }
}
