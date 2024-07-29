using Levantoso.Domain.Excel;
using Levantoso.Domain.Models;
using Levantoso.Web.ViewModel;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Levantoso.Web.Controllers
{
    public class LevantosoController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult AbrirGrupo(string nomeGrupo)
        {
            return View("_Grid", new List<GrupoModel> { new GrupoModel(nomeGrupo) });
        }

        [HttpPost]
        public ActionResult NovaLinhaGrid(ItemLevantamentoModel item)
        {
            return View("_RowGrid", item);
        }

        [HttpPost]
        public ActionResult ExportarParaExcel(ExportarExcelViewModel exportacao)
        {
            var excelContent = GeradorExcel.GerarPeloWeb(exportacao.Grupos);
            return File(excelContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", exportacao.NomeArquivo + ".xlsx");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var grupos = LeitorExcel.Processar(file?.InputStream);
            return View("_Grid", grupos);
        }
    }
}