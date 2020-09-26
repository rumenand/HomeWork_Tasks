using SIS.HTTP;
using SIS.HTTP.Logging;
using SIS.MvcFramework;
using SharedTrip.Data;
using SharedTrip.Models;

namespace SharedTrip.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        private readonly SharedTripDbContext db;

        public HomeController(ILogger logger, SharedTripDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }
        // /
        [HttpGet(url:"/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
        public HttpResponse Index()
        {
            logger.Log(this.User);
            return this.View();
        }
    }
}