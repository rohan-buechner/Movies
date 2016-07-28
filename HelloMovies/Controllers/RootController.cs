using System.Web.Mvc;

namespace HelloMovies.Controllers
{
    public class RootController : Controller
    {
        // we only utilize one server side rendered page to deliver out initial payloads; scripts; css; etc.
        // this allows us to in future cache angular views for performance benefits
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}