using AutoMapper;
using CityInfo.Api.Common;
using CityInfo.Api.DataContracts.ParentalFacilities;
using CityInfo.Modules.ParentalFacilities.Domain.Models;

namespace CityInfo.Modules.ParentalFacilities.Api.Mappers
{
    public interface ISearchParentalFacilitiesMapper : IMapper<SearchParentalFacilitiesDto, ListParentalFacilitiesQuery> { }

    public class SearchParentalFacilitiesMapper : ISearchParentalFacilitiesMapper
    {
        private readonly IMapper _mapper;

        public SearchParentalFacilitiesMapper()
        {
            _mapper = new MapperConfiguration(config => config.CreateMap<ParentalFacility, ParentalFacilityDto>())
                .CreateMapper();
        }

        public ListParentalFacilitiesQuery Map(SearchParentalFacilitiesDto input)
        {
            return _mapper.Map<ListParentalFacilitiesQuery>(input);
        }
    }
}
