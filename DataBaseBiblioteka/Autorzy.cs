using System;
using System.Collections.Generic;

namespace DataBaseBiblioteka;

public partial class Autorzy
{
    public int IdAutora { get; set; }

    public string? Imie { get; set; }

    public string? Nazwisko { get; set; }

    public virtual ICollection<Ksiazki> Ksiazkis { get; set; } = new List<Ksiazki>();


}
