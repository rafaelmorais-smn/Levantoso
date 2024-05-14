using System.Web.Mvc;

namespace Levantoso.Web.Controllers
{
    public class LevantosoController : Controller
    {
        // GET: Levantoso
        public ActionResult Index() => View();

        public ActionResult AbrirForm(string nome)
        {
            ViewBag.NomeGrupo = nome;
            return View("_gridDados");
        }
        public ActionResult GerarTabela(string nomeTabela)
        {
            ViewBag.NomeTabela = nomeTabela;
            return View("_gridTabelas");
        }

    }
}