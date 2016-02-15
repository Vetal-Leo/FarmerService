using System.Web.Mvc;

namespace Farmer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated) return Redirect("/UserSimple");
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
    }
}
