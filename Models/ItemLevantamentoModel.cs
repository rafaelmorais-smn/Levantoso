using Levantoso.Lists;

namespace Levantoso.Models
{
    public class ItemLevantamentoModel
    {
        public ItemLevantamentoModel(ComboItem item, ComboItem complexidade, string descricao)
        {
            Item = item;
            Complexidade = complexidade;
            Descricao = descricao;
        }

        public ComboItem Item { get; set; }
        public ComboItem Complexidade { get; set; }
        public string Descricao { get; set; }
    }
}
