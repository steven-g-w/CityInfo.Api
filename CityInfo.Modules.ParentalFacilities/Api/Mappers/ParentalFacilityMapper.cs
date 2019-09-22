using AutoMapper;
using CityInfo.Api.Common;
using CityInfo.Api.DataContracts.ParentalFacilities;
using CityInfo.Modules.ParentalFacilities.Domain.Models;

namespace CityInfo.Modules.ParentalFacilities.Api.Mappers
{
    public interface IParentalFacilityMapper : IMapper<ParentalFacility, ParentalFacilityDto> { }

    public class ParentalFacilityMapper : IParentalFacilityMapper
    {
        private readonly IMapper _mapper;

        public ParentalFacilityMapper()
        {
            var amenitiesMapper = new MapperConfiguration(config => config.CreateMap<ParentalFacility, ParentalFacilityAmenitiesStatusDto>()).CreateMapper();

            _mapper = new MapperConfiguration(config => config
                    .CreateMap<ParentalFacility, ParentalFacilityDto>()
                    .ForMember(dto => dto.Amenities,
                        opt => opt.MapFrom(pf => amenitiesMapper.Map<ParentalFacilityAmenitiesStatusDto>(pf))))
                .CreateMapper();
        }

        public ParentalFacilityDto Map(ParentalFacility input)
        {
            return _mapper.Map<ParentalFacilityDto>(input);
        }
    }
}
