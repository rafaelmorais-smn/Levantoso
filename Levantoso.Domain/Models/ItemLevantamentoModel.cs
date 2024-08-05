using Levantoso.Domain.Lists;

namespace Levantoso.Domain.Models
{
    public class ItemLevantamentoModel
    {
        public ItemLevantamentoModel()
        {
            
        }

        public ItemLevantamentoModel(ComboItem tipoAlteracao, ComboItem item, ComboItem complexidade, string descricao)
        {
            TipoOperacao = tipoAlteracao;
            Item = item;
            Complexidade = complexidade;
            Descricao = descricao;
        }

        public ComboItem TipoOperacao { get; set; }
        public ComboItem Item { get; set; }
        public ComboItem Complexidade { get; set; }
        public string Descricao { get; set; }
    }
}
