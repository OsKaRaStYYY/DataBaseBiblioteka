using System;
using System.Collections.Generic;

namespace DataBaseBiblioteka;

public partial class Ksiazki
{
    public int IdKsiazki { get; set; }

    public string? Tytul { get; set; }

    public int? IdAutora { get; set; }

    public DateTime? RokWydania { get; set; }

    public decimal? Wartosc { get; set; }

    public virtual Autorzy IdAutorzyNavigation { get; set; } = null!;






    public virtual ICollection<Wypozyczenie> Wypozyczenies { get; set; } = new List<Wypozyczenie>();

    public virtual ICollection<Zakup> Zakups { get; set; } = new List<Zakup>();
}
