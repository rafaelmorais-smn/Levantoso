using Levantoso.Excel;
using Levantoso.Web.Excel;
using Levantoso.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Levantoso.Web.Controllers
{
    public class LevantosoController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult AbrirForm(string nome)
        {
            ViewBag.NomeGrupo = nome;
            return View("_gridDados");
        }

        [HttpPost]
        public ActionResult ExportarParaExcel(IEnumerable<GrupoModel> grupos)
        {
            string nomeArquivo = grupos.FirstOrDefault()?.NomeArquivo;
            var excelContent = GeradorExcel.Gerar(grupos);
            return File(excelContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nomeArquivo + ".xlsx");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var grupos = LeitorExcel.Processar(file);
            return View("_gridDados", grupos);
        }

    }
}