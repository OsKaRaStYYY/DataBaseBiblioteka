using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBaseBiblioteka
{
    /// <summary>
    /// Interaction logic for ZakupAndWypozyczenie.xaml
    /// </summary>
    public partial class ZakupAndWypozyczenie : Window
    {
        public List<Zakup> zakup { get; set; }
        public List<Wypozyczenie> wypozyczenie { get; set; }
        private readonly BibliotekaContext _context4;
        public ZakupAndWypozyczenie()
        {
            InitializeComponent();

            _context4 = new BibliotekaContext();
            zakup = _context4.Zakups.ToList();
            wypozyczenie = _context4.Wypozyczenies.ToList();

            ZakupyList.ItemsSource = zakup;
            WypozyczenieList.ItemsSource = wypozyczenie;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var zakup = new Zakup()
            {
                IloscZakupu = Int32.TryParse(IloscText.Text, out int iloscParsed) ? iloscParsed : (int?)null,
                
                DataZakupu= DateTime.TryParse(DataZakupuText.Text, out DateTime dataZakupuParsed) ? dataZakupuParsed : (DateTime?)null,
                DataOtrzymania = DateTime.TryParse(DataOtrzymaniaText.Text, out DateTime DataOtrzymaniaParsed) ? DataOtrzymaniaParsed : (DateTime?)null,
               
                CenaZakupu = decimal.TryParse(CenaText.Text, out decimal pensjaParsed) ? pensjaParsed : 0m,
            };

            try
            {
                _context4.Zakups.Add(zakup);
                _context4.SaveChanges();
                ZakupyList.ItemsSource = _context4.Zakups.ToList();
                MessageBox.Show("Row added successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                IloscText.Text = "";
                DataZakupuText.Text = "";
                DataOtrzymaniaText.Text = "";
                CenaText.Text = "";
                
            }
            catch (DbUpdateException ex)
            {

                MessageBox.Show($"Something went wrong: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var wypozyczenie = new Wypozyczenie()
            {
                

                DataWypozyczenia = DateTime.TryParse(DataWypozyczeniaText.Text, out DateTime dataZakupuParsed) ? dataZakupuParsed : (DateTime?)null,
                DataZwrotu = DateTime.TryParse(DataZwrotuText.Text, out DateTime DataOtrzymaniaParsed) ? DataOtrzymaniaParsed : (DateTime?)null,

                
            };

            try
            {
                _context4.Wypozyczenies.Add(wypozyczenie);
                _context4.SaveChanges();
                WypozyczenieList.ItemsSource = _context4.Wypozyczenies.ToList();
                MessageBox.Show("Row added successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                DataWypozyczeniaText.Text = "";
                DataZwrotuText.Text = "";
                

            }
            catch (DbUpdateException ex)
            {

                MessageBox.Show($"Something went wrong: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(IDDeleteZakupText.Text, out int idToDelete))
            {
                var zakupToDelete = _context4.Zakups.FirstOrDefault(k => k.IdZakupu == idToDelete);
                //var autorzyToDelete = _context2.Autorzies.FirstOrDefault(k => k.IdAutora == idToDelete);

                if (zakupToDelete != null)
                {
                    _context4.Zakups.Remove(zakupToDelete);

                    _context4.SaveChanges();

                    MessageBox.Show("Row deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                    ZakupyList.ItemsSource = _context4.Zakups.ToList();
                }

                else
                {
                    MessageBox.Show("Row with the provided ID does not exist.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid ID format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(IDDeletewypozycznieText.Text, out int idToDelete))
            {
                var wypozyczenieToDelete = _context4.Wypozyczenies.FirstOrDefault(k => k.IdWypozyczenia == idToDelete);
                //var autorzyToDelete = _context2.Autorzies.FirstOrDefault(k => k.IdAutora == idToDelete);

                if (wypozyczenieToDelete != null)
                {
                    _context4.Wypozyczenies.Remove(wypozyczenieToDelete);

                    _context4.SaveChanges();

                    MessageBox.Show("Row deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                    WypozyczenieList.ItemsSource = _context4.Wypozyczenies.ToList();
                }

                else
                {
                    MessageBox.Show("Row with the provided ID does not exist.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid ID format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
                PracownicyWindow newWindow5 = new PracownicyWindow();
                newWindow5.Show();
                this.Close();
            
        }
    }
}
