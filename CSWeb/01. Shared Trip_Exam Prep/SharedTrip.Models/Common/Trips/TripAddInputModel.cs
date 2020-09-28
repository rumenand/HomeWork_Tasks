using System;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models.Common.Trips
{
    public class TripAddInputModel
    {
        public string Id { get; set; }
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        [Range(2,6)]
        public short Seats { get; set; }
        [Required]
        [MaxLength(80)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
