namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        // /
        [HttpGet(url:"/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}