using CityInfo.Domain.Common.Entities;
using System;

namespace CityInfo.Modules.ParentalFacilities.Domain.Models
{
    public class ParentalFacility : DatabaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTimeOffset LastCleanedAt { get; set; }

        public bool Microwave { get; set; }
        public bool ChangeTable { get; set; }
        public bool RubbishBin { get; set; }
        public bool Toilet { get; set; }
        public bool Shower { get; set; }
        public bool Television { get; set; }
        public bool MusicPlayer { get; set; }
        public bool HighChair { get; set; }
        public bool SittingChair { get; set; }
    }
}
