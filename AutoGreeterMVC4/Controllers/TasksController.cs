using System.Web.Mvc;

namespace AutoGreeterMVC4.Controllers
{
    public class TasksController : Controller
    {
        //
        // GET: /Tasks/

        public ActionResult Index()
        {
            return View();
        }
    }
}
