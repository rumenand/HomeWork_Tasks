using System;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.ViewModels.Trips
{
    public class TripViewModel
    {
        public string Id { get; set; }
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public short Seats { get; set; }
    }
}
