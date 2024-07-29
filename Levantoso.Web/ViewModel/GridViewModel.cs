using Levantoso.Domain.Models;
using System.Collections.Generic;

namespace Levantoso.Web.ViewModel
{
    public class GridViewModel
    {
        public string NomeGrupo { get; set; }
        public IEnumerable<GrupoModel> Grupos { get; set; }
    }
}