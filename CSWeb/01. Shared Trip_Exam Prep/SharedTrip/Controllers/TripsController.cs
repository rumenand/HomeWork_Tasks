using SharedTrip.Models.Common.Trips;
using SharedTrip.ViewModels.Trips;
using SharedTrip.Services;
using SIS.HTTP;
using SIS.MvcFramework;
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
            var viewModel = new AllTripsViewModel
            {
                Trips = this.tripService.GetAll().Select(x=> new TripViewModel
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
                return this.Error("Are you crazy?");
               // return this.View();
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
        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var targetTrip = this.tripService.GetDetails(tripId);
            var viewModel = new TripDetailsViewModel
            {
                Id = targetTrip.Id,
                ImagePath = targetTrip.ImagePath,
                StartPoint = targetTrip.StartPoint,
                EndPoint = targetTrip.EndPoint,
                DepartureTime = targetTrip.DepartureTime.ToString("yyyy-MM-dd HH:mm").Replace(" ","T"),
                Description = targetTrip.Description,
                Seats = tripService.GetTripFreePlaces(targetTrip)
            };
            return this.View(viewModel);
        }
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
             var result = tripService.TryAddUserToTrip(tripId,this.User);           
           
            return this.Redirect("/Trips/JoinResult/"+result);
        }
        [HttpGet(url: "/Trips/JoinResult/AlreadyIn")]
        public HttpResponse AlreadyIn()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
    }
}
