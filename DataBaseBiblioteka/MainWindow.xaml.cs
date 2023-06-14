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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseBiblioteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Klienci> klienci { get; set; }
        private readonly BibliotekaContext _context;

        public MainWindow()
        {
            InitializeComponent();

            _context = new BibliotekaContext();
            klienci = _context.Kliencis.ToList();

            KsiazkiList.ItemsSource = klienci;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
           

            var klient = new Klienci()
            {
                
                Imie = NameText.Text,
                Nazwisko = LastNameText.Text,
                
                DataUrodzenia = DateTime.TryParse(DataUrodzeniaText.Text, out DateTime dataUrodzeniaParsed) ? dataUrodzeniaParsed : (DateTime?)null,
                Ulica = UlicaText.Text,
               
                NumerDomu = Int32.TryParse(NumerDomuText.Text, out int numerDomuParsed) ? numerDomuParsed : (int?)null,
                Kraj = KrajText.Text,
                
                Telefon = Int32.TryParse(TelefonText.Text, out int telefonParsed) ? telefonParsed : (int?)null
            };

            _context.Kliencis.Add(klient);
            _context.SaveChanges();
            KsiazkiList.ItemsSource = _context.Kliencis.ToList();
            MessageBox.Show("Row added successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LastNameText.Text = "";
            NameText.Text = "";
            DataUrodzeniaText.Text = "";
            NumerDomuText.Text = "";
            KrajText.Text = "";
            TelefonText.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                if (Int32.TryParse(IDDeleteText.Text, out int idToDelete))
                {
                    var klientToDelete = _context.Kliencis.FirstOrDefault(k => k.IdKlienta == idToDelete);

                    if (klientToDelete != null)
                    {
                        _context.Kliencis.Remove(klientToDelete);
                        _context.SaveChanges();

                        MessageBox.Show("Row deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        
                        KsiazkiList.ItemsSource = _context.Kliencis.ToList();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewWindowKsiazki newWindow = new NewWindowKsiazki();
            newWindow.Show();
            this.Close();
        }
    }
}
