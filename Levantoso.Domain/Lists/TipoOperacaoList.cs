using System.Collections.Generic;

namespace Levantoso.Domain.Lists
{
    public static class TipoOperacaoList
    {
        public static IEnumerable<ComboItem> ComboValues = new List<ComboItem>
        {
            new ComboItem(0, "Selecione o tipo da operação"),
            new ComboItem(1, "Criação"),
            new ComboItem(2, "Alteração"),
        };
    }
}
