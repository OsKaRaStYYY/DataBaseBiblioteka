using System;
using System.Collections.Generic;

namespace DataBaseBiblioteka;

public partial class Zakup
{
    public int IdZakupu { get; set; }

    public int? IdPracownika { get; set; }

    public int? IdKsiazki { get; set; }

    public int? IdKlienta { get; set; }

    public DateTime? DataZakupu { get; set; }

    public DateTime? DataOtrzymania { get; set; }

    public decimal? CenaZakupu { get; set; }

    public int? IloscZakupu { get; set; }

    public virtual Klienci? IdKlientaNavigation { get; set; }

    public virtual Ksiazki? IdKsiazkiNavigation { get; set; }

    public virtual Pracownicy? IdPracownikaNavigation { get; set; }
}
