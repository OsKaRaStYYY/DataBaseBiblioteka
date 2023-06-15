using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseBiblioteka;

public partial class BibliotekaContext : DbContext
{
    public BibliotekaContext()
    {
    }

    public BibliotekaContext(DbContextOptions<BibliotekaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autorzy> Autorzies { get; set; }

    public virtual DbSet<Klienci> Kliencis { get; set; }

    public virtual DbSet<Ksiazki> Ksiazkis { get; set; }

    public virtual DbSet<Pracownicy> Pracownicies { get; set; }

    public virtual DbSet<Wypozyczenie> Wypozyczenies { get; set; }

    public virtual DbSet<Zakup> Zakups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BIBLIOTEKA;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autorzy>(entity =>
        {
            entity.HasKey(e => e.IdAutora).HasName("PK__Autorzy__89EE25ACFA764891");

            entity.ToTable("Autorzy");

            entity.Property(e => e.IdAutora).HasColumnName("ID_Autora");
            entity.Property(e => e.Imie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Klienci>(entity =>
        {
            entity.HasKey(e => e.IdKlienta).HasName("PK__Klienci__4023806447500412");

            entity.ToTable("Klienci");

            entity.Property(e => e.IdKlienta).HasColumnName("ID_Klienta");
            entity.Property(e => e.DataUrodzenia)
                .HasColumnType("date")
                .HasColumnName("Data_urodzenia");
            entity.Property(e => e.Imie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Kraj)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumerDomu).HasColumnName("Numer_Domu");
            entity.Property(e => e.Ulica)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ksiazki>(entity =>
        {
            entity.HasKey(e => e.IdKsiazki).HasName("PK__Ksiazki__EBC0CB236E9439A2");

            entity.ToTable("Ksiazki");

            entity.Property(e => e.IdKsiazki).HasColumnName("ID_Ksiazki");
            entity.Property(e => e.IdAutora).HasColumnName("ID_Autora");
            entity.Property(e => e.RokWydania)
                .HasColumnType("date")
                .HasColumnName("Rok_Wydania");
            entity.Property(e => e.Tytul)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Wartosc).HasColumnType("money");

            entity.HasOne(d => d.IdAutorzyNavigation).WithMany(p => p.Ksiazkis)
                .HasForeignKey(d => d.IdAutora)
                .HasConstraintName("FK__Ksiazki__ID_Auto__29572725");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.HasKey(e => e.IdPracownika).HasName("PK__Pracowni__7DC477B53F6B578D");

            entity.ToTable("Pracownicy");

            entity.HasIndex(e => e.Pesel, "pes").IsUnique();

            entity.Property(e => e.IdPracownika).HasColumnName("ID_Pracownika");
            entity.Property(e => e.DataUrodzenia)
                .HasColumnType("date")
                .HasColumnName("Data_urodzenia");
            entity.Property(e => e.DataZatrudnienia)
                .HasColumnType("date")
                .HasColumnName("Data_zatrudnienia");
            entity.Property(e => e.Imie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Kraj)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumerDomu).HasColumnName("Numer_Domu");
            entity.Property(e => e.Pensja).HasColumnType("money");
            entity.Property(e => e.Stanowisko)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ulica)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Wypozyczenie>(entity =>
        {
            entity.HasKey(e => e.IdWypozyczenia).HasName("PK__Wypozycz__C62920D50ADBEBA2");

            entity.ToTable("Wypozyczenie");

            entity.Property(e => e.IdWypozyczenia).HasColumnName("ID_Wypozyczenia");
            entity.Property(e => e.DataWypozyczenia)
                .HasColumnType("date")
                .HasColumnName("Data_Wypozyczenia");
            entity.Property(e => e.DataZwrotu)
                .HasColumnType("date")
                .HasColumnName("Data_Zwrotu");
            entity.Property(e => e.IdKlienta).HasColumnName("ID_Klienta");
            entity.Property(e => e.IdKsiazki).HasColumnName("ID_Ksiazki");
            entity.Property(e => e.IdPracownika).HasColumnName("ID_Pracownika");

            entity.HasOne(d => d.IdKlientaNavigation).WithMany(p => p.Wypozyczenies)
                .HasForeignKey(d => d.IdKlienta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wypozycze__ID_Kl__2F10007B");

            entity.HasOne(d => d.IdKsiazkiNavigation).WithMany(p => p.Wypozyczenies)
                .HasForeignKey(d => d.IdKsiazki)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wypozycze__ID_Ks__300424B4");

            entity.HasOne(d => d.IdPracownikaNavigation).WithMany(p => p.Wypozyczenies)
                .HasForeignKey(d => d.IdPracownika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wypozycze__ID_Pr__2E1BDC42");
        });

        modelBuilder.Entity<Zakup>(entity =>
        {
            entity.HasKey(e => e.IdZakupu).HasName("PK__Zakup__C118400292B9F4C6");

            entity.ToTable("Zakup");

            entity.Property(e => e.IdZakupu).HasColumnName("ID_Zakupu");
            entity.Property(e => e.CenaZakupu)
                .HasColumnType("money")
                .HasColumnName("Cena_Zakupu");
            entity.Property(e => e.DataOtrzymania)
                .HasColumnType("date")
                .HasColumnName("Data_Otrzymania");
            entity.Property(e => e.DataZakupu)
                .HasColumnType("date")
                .HasColumnName("Data_Zakupu");
            entity.Property(e => e.IdKlienta).HasColumnName("ID_Klienta");
            entity.Property(e => e.IdKsiazki).HasColumnName("ID_Ksiazki");
            entity.Property(e => e.IdPracownika).HasColumnName("ID_Pracownika");
            entity.Property(e => e.IloscZakupu).HasColumnName("Ilosc_Zakupu");

            entity.HasOne(d => d.IdKlientaNavigation).WithMany(p => p.Zakups)
                .HasForeignKey(d => d.IdKlienta)
                .HasConstraintName("FK__Zakup__ID_Klient__32E0915F");

            entity.HasOne(d => d.IdKsiazkiNavigation).WithMany(p => p.Zakups)
                .HasForeignKey(d => d.IdKsiazki)
                .HasConstraintName("FK__Zakup__ID_Ksiazk__34C8D9D1");

            entity.HasOne(d => d.IdPracownikaNavigation).WithMany(p => p.Zakups)
                .HasForeignKey(d => d.IdPracownika)
                .HasConstraintName("FK__Zakup__ID_Pracow__33D4B598");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
