namespace Levantoso.Web.Models
{
    public class ItemLevantamentoModel
    {
        public ItemLevantamentoModel()
        {
            
        }

        public ItemLevantamentoModel(string item, byte idItem, string complexidade, byte idComplexidade, string descricao)
        {
            Item = item;
            IdItem = idItem;
            IdComplexidade = idComplexidade;
            Complexidade = complexidade;
            Descricao = descricao;
        }

        public string Item { get; set; }
        public byte IdItem { get; set; }
        public string Complexidade { get; set; }
        public byte IdComplexidade { get; set; }
        public string Descricao { get; set; }
    }
}
