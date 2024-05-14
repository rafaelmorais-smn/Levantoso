namespace Levantoso.Models
{
    public class ItemLevantamentoAgrupadoModel
    {
        public ItemLevantamentoAgrupadoModel(byte codigoItem, byte codigoComplexidade, byte quantidade)
        {
            CodigoItem = codigoItem;
            CodigoComplexidade = codigoComplexidade;
            Quantidade = quantidade;
        }

        public byte CodigoItem { get; set; }
        public byte CodigoComplexidade { get; set; }
        public byte Quantidade { get; set; }
    }
}
