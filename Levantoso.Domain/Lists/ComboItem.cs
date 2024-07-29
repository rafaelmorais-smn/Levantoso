namespace Levantoso.Domain.Lists
{
    public class ComboItem
    {
        public ComboItem()
        {
            
        }

        public ComboItem(byte valor, string descricao)
        {
            Value = valor;
            Text = descricao;
        }

        public byte Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
