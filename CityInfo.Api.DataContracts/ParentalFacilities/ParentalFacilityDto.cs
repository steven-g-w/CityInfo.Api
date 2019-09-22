using System;

namespace CityInfo.Api.DataContracts.ParentalFacilities
{
    public class ParentalFacilityDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTimeOffset LastCleanedAt { get; set; }
        public ParentalFacilityAmenitiesStatusDto Amenities { get; set; }
    }
}
