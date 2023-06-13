using System;
using System.Collections.Generic;

namespace DataBaseBiblioteka;

public partial class Wypozyczenie
{
    public int IdWypozyczenia { get; set; }

    public int IdPracownika { get; set; }

    public int IdKlienta { get; set; }

    public int IdKsiazki { get; set; }

    public DateTime? DataWypozyczenia { get; set; }

    public DateTime? DataZwrotu { get; set; }

    public virtual Klienci IdKlientaNavigation { get; set; } = null!;

    public virtual Ksiazki IdKsiazkiNavigation { get; set; } = null!;

    public virtual Pracownicy IdPracownikaNavigation { get; set; } = null!;
}
