using Microsoft.Data.SqlClient;
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
    /// Interaction logic for NewWindowKsiazki.xaml
    /// </summary>
    public partial class NewWindowKsiazki : Window
    {
        public List<Ksiazki> ksiazki { get; set; }
        public List<Autorzy> autorzy { get; set; }
        private readonly BibliotekaContext _context2;
        public NewWindowKsiazki()
        {
            InitializeComponent();

            _context2 = new BibliotekaContext();
            ksiazki = _context2.Ksiazkis.ToList();
            autorzy = _context2.Autorzies.ToList();

            KsiazkiList.ItemsSource = ksiazki;
            AutorzyList.ItemsSource = autorzy;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string tytul = TytulText.Text;
            string rokWydania = RokWydaniaText.Text;
            string wartosc = WartoscText.Text;
            string imieAutora = ImieAutoraText.Text;
            string nazwiskoAutora = NazwiskoAutoraText.Text;

            Autorzy nowyAutor = new Autorzy
            {
                Imie = imieAutora,
                Nazwisko = nazwiskoAutora
                
            };

            Ksiazki nowaKsiazka = new Ksiazki
            {
                Tytul = tytul,
                RokWydania = DateTime.Parse(rokWydania),
                Wartosc = decimal.Parse(wartosc),
                IdAutorzyNavigation = nowyAutor
            };

            
            _context2.Add(nowyAutor);
            _context2.SaveChanges();

            
            _context2.Add(nowaKsiazka);
            _context2.SaveChanges();


            KsiazkiList.ItemsSource = _context2.Ksiazkis.ToList();
            AutorzyList.ItemsSource = _context2.Autorzies.ToList();

            MessageBox.Show("Row added successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            
            TytulText.Text = "";
            RokWydaniaText.Text = "";
            WartoscText.Text = "";
            ImieAutoraText.Text = "";
            NazwiskoAutoraText.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(IDDeleteText2.Text, out int idToDelete))
            {
                var ksiazkiToDelete = _context2.Ksiazkis.FirstOrDefault(k => k.IdKsiazki == idToDelete);
                //var autorzyToDelete = _context2.Autorzies.FirstOrDefault(k => k.IdAutora == idToDelete);

                if (ksiazkiToDelete != null)
                {
                    _context2.Ksiazkis.Remove(ksiazkiToDelete);

                    _context2.SaveChanges();

                    MessageBox.Show("Row deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                    KsiazkiList.ItemsSource = _context2.Kliencis.ToList();
                }
                //else if (autorzyToDelete != null)
                //{
                //    _context2.Autorzies.Remove(autorzyToDelete);
                //    _context2.SaveChanges();
                //    AutorzyList.ItemsSource = _context2.Autorzies.ToList();
                //}
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
            if (Int32.TryParse(IDDeleteText3.Text, out int idToDelete))
            {
                var autorzyToDelete = _context2.Autorzies.FirstOrDefault(k => k.IdAutora == idToDelete);
                //var autorzyToDelete = _context2.Autorzies.FirstOrDefault(k => k.IdAutora == idToDelete);

                if (autorzyToDelete != null)
                {
                    _context2.Autorzies.Remove(autorzyToDelete);

                    _context2.SaveChanges();

                    MessageBox.Show("Row deleted successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                    AutorzyList.ItemsSource = _context2.Autorzies.ToList();
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
            MainWindow newWindow2 = new MainWindow();
            newWindow2.Show();
            this.Close();
        }
    }
}
