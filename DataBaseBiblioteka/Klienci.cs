using System;
using System.Collections.Generic;

namespace DataBaseBiblioteka;

public partial class Klienci
{
    public int IdKlienta { get; set; }

    public string? Imie { get; set; }

    public string? Nazwisko { get; set; }

    public DateTime? DataUrodzenia { get; set; }

    public string? Ulica { get; set; }

    public int? NumerDomu { get; set; }

    public string? Kraj { get; set; }

    public int? Telefon { get; set; }

    public virtual ICollection<Wypozyczenie> Wypozyczenies { get; set; } = new List<Wypozyczenie>();

    public virtual ICollection<Zakup> Zakups { get; set; } = new List<Zakup>();
}
