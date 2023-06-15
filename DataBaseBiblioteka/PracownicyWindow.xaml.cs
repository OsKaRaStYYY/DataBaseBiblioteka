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
    /// Interaction logic for PracownicyWindow.xaml
    /// </summary>
    public partial class PracownicyWindow : Window
    {
        public List<Pracownicy> pracownicy { get; set; }
        
        private readonly BibliotekaContext _context3;
        public PracownicyWindow()
        {
            InitializeComponent();

            _context3 = new BibliotekaContext();
            pracownicy = _context3.Pracownicies.ToList();
            

            PracownicyList.ItemsSource = pracownicy;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pracownicy = new Pracownicy()
            {
                Imie = NameText.Text,
                Nazwisko = LastNameText.Text,
                DataUrodzenia = DateTime.TryParse(DataUrodzeniaText.Text, out DateTime dataUrodzeniaParsed) ? dataUrodzeniaParsed : (DateTime?)null,
                DataZatrudnienia = DateTime.TryParse(DataZatrudnieniaText.Text, out DateTime dataZatrudnieniaParsed) ? dataZatrudnieniaParsed : (DateTime?)null,
                Ulica = UlicaText.Text,
                NumerDomu = Int32.TryParse(NumerDomuText.Text, out int numerDomuParsed) ? numerDomuParsed : (int?)null,
                Kraj = KrajText.Text,
                Pesel = Int32.TryParse(PeselText.Text, out int PeselParsed) ? PeselParsed : (int?)null, 
                Stanowisko = StanowiskoText.Text,
                Pensja = decimal.TryParse(PensjaText.Text, out decimal pensjaParsed) ? pensjaParsed : 0m, 
            };

            try
            {
                _context3.Pracownicies.Add(pracownicy);
                _context3.SaveChanges();
                PracownicyList.ItemsSource = _context3.Pracownicies.ToList();
                MessageBox.Show("Row added successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                
                LastNameText.Text = "";
                NameText.Text = "";
                DataUrodzeniaText.Text = "";
                DataZatrudnieniaText.Text = "";
                NumerDomuText.Text = "";
                KrajText.Text = "";
                PeselText.Text = "";
                StanowiskoText.Text = "";
                PensjaText.Text = "";
            }
            catch (DbUpdateException ex)
            {
               
                MessageBox.Show($"Something went wrong: {ex.InnerException.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewWindowKsiazki newWindow3 = new NewWindowKsiazki();
            newWindow3.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (int.TryParse(DeletePracownikText.Text, out int idPracownika))
            {
             
                var pracownikDoUsuniecia = _context3.Pracownicies.SingleOrDefault(p => p.IdPracownika == idPracownika);

                if (pracownikDoUsuniecia != null)
                {
                    _context3.Pracownicies.Remove(pracownikDoUsuniecia);
                    _context3.SaveChanges();

                   
                    PracownicyList.ItemsSource = _context3.Pracownicies.ToList();

                    MessageBox.Show("Row deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("ID not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                
                DeletePracownikText.Text = "";
            }
            else
            {
                MessageBox.Show("ID is wrong.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ZakupAndWypozyczenie newWindow4 = new ZakupAndWypozyczenie();
            newWindow4.Show();
            this.Close();
        }
    }
}
