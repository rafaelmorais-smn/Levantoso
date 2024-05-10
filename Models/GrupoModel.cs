using System.Collections.Generic;

namespace Levantoso.Models
{
    public class GrupoModel
    {
        public string NomeGrupo { get; set; }
        public IEnumerable<ItemLevantamentoModel> Itens { get; set; }
    }
}
