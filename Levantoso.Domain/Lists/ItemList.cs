using System.Collections.Generic;

namespace Levantoso.Domain.Lists
{
    public static class ItemList
    {
        public static IEnumerable<ComboItem> ComboValues = new List<ComboItem>
        {
            new ComboItem(0, "Selecione o Item"),
            new ComboItem(1, "Tela"),
            new ComboItem(3, "PDF"),
            new ComboItem(4, "Excel"),
            new ComboItem(5, "Procedure"),
            new ComboItem(6, "JOB"),
            new ComboItem(7, "Trigger"),
            new ComboItem(8, "Função"),
            new ComboItem(9, "Script"),
            new ComboItem(10, "Modelagem"),
            new ComboItem(11, "API"),
            new ComboItem(12, "Console"),
        };
    }
}
