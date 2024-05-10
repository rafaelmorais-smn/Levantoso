using System.Collections.Generic;

namespace Levantoso.Lists
{
    public static class ItemList
    {
        public static IEnumerable<ComboItem> ComboValues = new List<ComboItem>
        {
            new ComboItem(0, "Selecione"),
            new ComboItem(1, "Tabela"),
            new ComboItem(2, "Formulário"),
            new ComboItem(3, "Procedure"),
            new ComboItem(4, "JOB"),
            new ComboItem(5, "Trigger"),
            new ComboItem(6, "Função"),
            new ComboItem(7, "Script"),
            new ComboItem(8, "Modelagem"),
            new ComboItem(9, "API"),
            new ComboItem(10, "Console"),
            new ComboItem(11, "PDF"),
            new ComboItem(12, "Excel"),
        };
    }
}
