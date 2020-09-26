
using SharedTrip.Models;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        public TripsController()
        {

        }
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

           
            return this.View();
        }

        public HttpResponse Add()
        {
            return this.View();
        }
    }
}
