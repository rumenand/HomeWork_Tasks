
namespace SharedTrip.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    public class UsersController : Controller
    {
        public HttpResponse Register()
        {
            return this.View();
        }

        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
