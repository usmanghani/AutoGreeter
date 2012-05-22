using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Data.EntityFramework;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoGreeterMVC4.Controllers
{
    public partial class AutoGreeterMVC4Controller : DbDataController<AutoGreeterMVC4.Models.AutoGreeterMVC4Context>
    {
        // Any code added here will apply to all entity types managed by this data controller
    }

    // This provides context-specific route registration
    public class AutoGreeterMVC4RouteRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "AutoGreeterMVC4"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
			RouteTable.Routes.MapHttpRoute(
                "AutoGreeterMVC4", // Route name
                "api/AutoGreeterMVC4/{action}", // URL with parameters
                new { controller = "AutoGreeterMVC4" } // Parameter defaults
            );
        }
    }
}
