﻿using System.Collections.Generic;

namespace Levantoso.Lists
{
    public static class ComplexidadeList
    {
        public static IEnumerable<ComboItem> ComboValues = new List<ComboItem>
        {
            new ComboItem(0, "Selecione"),
            new ComboItem(1, "Simples"),
            new ComboItem(2, "Médio"),
            new ComboItem(3, "Complexo")
        };
    }
}
