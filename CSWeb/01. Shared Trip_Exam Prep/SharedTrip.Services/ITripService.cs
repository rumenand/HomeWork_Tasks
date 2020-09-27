using SharedTrip.Data.Models;
using SharedTrip.Models.Common.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        void Add(TripAddInputModel inputModel);

        IEnumerable<Trip> GetAll();

        Trip GetDetails(string id);
        bool TryAddUserToTrip(string tripId, string userId);
    }
}
