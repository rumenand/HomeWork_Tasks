using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Common.Trips;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly SharedTripDbContext dbContext;

        public TripService(SharedTripDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(TripAddInputModel inputModel)
        {
            var trip = new Trip()
            {
                Id = Guid.NewGuid().ToString(),
                StartPoint = inputModel.StartPoint,
                EndPoint = inputModel.Description,
                DepartureTime = inputModel.DepartureTime,
                Seats = inputModel.Seats,
                Description = inputModel.Description,
                ImagePath = inputModel.ImagePath
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();
        }
       

        public IEnumerable<Trip> GetAll()
        {
            return this.dbContext.Trips.ToList();
        }

        public Trip GetDetails(string id)
        {
            return dbContext.Trips.Where(x => x.Id == id).FirstOrDefault();
        }

        public string TryAddUserToTrip (string tripId, string userId)
        {
            var targetTrip = this.GetDetails(tripId);
            if (checkUserIsJoinedOnTrip(targetTrip,userId))
            {
                return "AlreadyIn";
            }
            if (this.GetTripFreePlaces(targetTrip) == 0)
            {
                return "Occupied";
            }
            var newUserTrip = new UserTrip
            {
                Trip = targetTrip,
                UserId = userId
            };
            dbContext.UserTrips.Add(newUserTrip);
            dbContext.SaveChanges();
            return "Success";
        }

        private bool checkUserIsJoinedOnTrip(Trip targetTrip, string userId)
        {
            return dbContext.UserTrips.Any(x => x.Trip == targetTrip && x.UserId == userId);
        }

        public short GetTripFreePlaces(Trip trip)
        {
            return (short)(trip.Seats - dbContext.UserTrips.Where(x => x.TripId == trip.Id).Count());
        }
        
    }
}
