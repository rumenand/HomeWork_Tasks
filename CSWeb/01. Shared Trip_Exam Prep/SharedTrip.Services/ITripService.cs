using SharedTrip.Data.Models;
using SharedTrip.Models.Common.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        void Add(TripAddInputModel inputModel);

        IEnumerable<Trip> GetAll();

        object GetDetails(string id);
    }
}
