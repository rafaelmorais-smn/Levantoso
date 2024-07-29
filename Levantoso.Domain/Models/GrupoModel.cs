using System.Collections.ObjectModel;

namespace Levantoso.Domain.Models
{
    public class GrupoModel
    {
        public GrupoModel()
        {

        }

        public GrupoModel(string nomeGrupo)
        {
            NomeGrupo = nomeGrupo;
            Itens = new Collection<ItemLevantamentoModel>();
        }
        public string NomeGrupo { get; set; }
        public Collection<ItemLevantamentoModel> Itens { get; set; }
    }
}
