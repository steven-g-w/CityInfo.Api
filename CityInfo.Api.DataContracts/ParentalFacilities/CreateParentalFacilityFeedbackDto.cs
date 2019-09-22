using System.ComponentModel.DataAnnotations;

namespace CityInfo.Api.DataContracts.ParentalFacilities
{
    public class CreateParentalFacilityFeedbackDto
    {
        [Required]
        public string ParentalFacilityId { get; set; }

        [Required]
        [Range(0, 5)]
        public int? Rating { get; set; }

        public string Comment { get; set; }


    }
}
