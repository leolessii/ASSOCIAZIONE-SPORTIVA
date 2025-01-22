using AssociazioneSportiva;
using Microsoft.Win32;
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

namespace WpfAssociazione
{
    /// <summary>
    /// Logica di interazione per HomeAssociazione.xaml
    /// </summary>
    public partial class HomeAssociazione : Window
    {
        public Associazione associazione;
        public Tesserato? tesseratoSelezionato;
        public HomeAssociazione(Associazione a)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.NoResize;
            associazione = a;
            lblNome.Content = "Associazione" + " " + associazione.Nome;
            lstTesserati.ItemsSource = associazione.Tesserati;
            tesseratoSelezionato = null;
        }
        private void AggiornaListe()
        {
            lstTesserati.ItemsSource = null;
            lstTesserati.ItemsSource = associazione.Tesserati;
        }

        private void lstTesserati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstTesserati.SelectedItem != null)
            {
                Tesserato a = lstTesserati.SelectedItem as Tesserato;
                lbl5.Content = $"{a.Nome} \n {a.Cognome} \n {a.NumeroTelefono} \n {a.DataNascita}";
                tesseratoSelezionato = a as Tesserato;
            }
        }


        private void btn_ModificaSpecialiàAssociazione_Click(object sender, RoutedEventArgs e)
        {
            specialitaAssociazione sa = new specialitaAssociazione(associazione);
            sa.Show();
            this.Close();
        }

        private void btn_ModificaAtleta_Click(object sender, RoutedEventArgs e)
        {
            ModificaAtleti ma = new ModificaAtleti(associazione);
            ma.Show();
            this.Close();
        }

        private void btn_ModificaIstruttore_Click(object sender, RoutedEventArgs e)
        {
            ModificaIstruttore mi = new ModificaIstruttore(associazione);
            mi.Show(); 
            this.Close();
        }

        private void btn_ModificaAmministratore_Click(object sender, RoutedEventArgs e)
        {
            ModificaAmministratore mam = new ModificaAmministratore(associazione);
            mam.Show();
            this.Close();
        }
    }
}
