
using SharedTrip.Models;
using SharedTrip.Models.Common.Trips;
using SharedTrip.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        public TripsController(ITripService tripService)
        {
            this.tripService = tripService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allTrips = this.tripService.GetAll();

            var viewModel = new AllTripsViewModel
            {
                Trips = allTrips.Select(x=>new TripViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats
                }).ToList()
            };
                   
            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripAddInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(inputModel.StartPoint) || string.IsNullOrEmpty(inputModel.EndPoint))
            {
                return this.View();
            }

            if (inputModel.Seats < 2 || inputModel.Seats > 6)
            {
                return this.View();
            }

            if (string.IsNullOrEmpty(inputModel.Description) || inputModel.Description.Length > 80)
            {
                return this.View();
            }


            this.tripService.Add(inputModel);

            return this.Redirect($"/Trips/All");
        }
    }
}
