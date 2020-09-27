using System;

namespace SharedTrip.Models.Common.Trips
{
    public class TripAddInputModel
    {
        public string Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public short Seats { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
