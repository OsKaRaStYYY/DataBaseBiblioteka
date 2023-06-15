using System;
using System.Collections.Generic;

namespace DataBaseBiblioteka;

public partial class Pracownicy
{
    public int IdPracownika { get; set; }

    public string? Imie { get; set; }

    public string? Nazwisko { get; set; }

    public DateTime? DataUrodzenia { get; set; }

    public DateTime? DataZatrudnienia { get; set; }

    public string? Ulica { get; set; }

    public int? NumerDomu { get; set; }

    public string? Kraj { get; set; }

    public int? Pesel { get; set; }

    public string? Stanowisko { get; set; }

    public decimal? Pensja { get; set; } = default(decimal?);

    public virtual ICollection<Wypozyczenie> Wypozyczenies { get; set; } = new List<Wypozyczenie>();

    public virtual ICollection<Zakup> Zakups { get; set; } = new List<Zakup>();
}
