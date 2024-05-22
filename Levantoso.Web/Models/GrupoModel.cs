using System.Collections.ObjectModel;

namespace Levantoso.Web.Models
{
    public class GrupoModel
    {
        public GrupoModel()
        {

        }

        public GrupoModel(string nomeGrupo, string nomeArquivo)
        {
            NomeGrupo = nomeGrupo;
            NomeArquivo = nomeArquivo;
            Itens = new Collection<ItemLevantamentoModel>();
        }
        public string NomeArquivo { get; set; }
        public string NomeGrupo { get; set; }
        public Collection<ItemLevantamentoModel> Itens { get; set; }
    }
}
