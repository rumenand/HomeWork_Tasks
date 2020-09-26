using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class Trip
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
        [Required]
        [MaxLength(80)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}
