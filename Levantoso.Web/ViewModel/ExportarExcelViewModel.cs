using Levantoso.Domain.Models;
using System.Collections.Generic;

namespace Levantoso.Web.ViewModel
{
    public class ExportarExcelViewModel
    {
        public IEnumerable<GrupoModel> Grupos { get; set; }
        public string NomeArquivo { get; set; }
    }
}