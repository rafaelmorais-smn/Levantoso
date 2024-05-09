using System.Web.Mvc;

namespace Levantoso.Web.Controllers
{
    public class LevantosoController : Controller
    {
        // GET: Levantoso
        public ActionResult Index() => View();

        public ActionResult AbrirGrids()
        {
            return View("_gridForm");
        }
    }
}