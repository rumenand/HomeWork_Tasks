using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Models
{
    public class TripInfoViewModel
    {
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public short Seats { get; set; }
    }
}
