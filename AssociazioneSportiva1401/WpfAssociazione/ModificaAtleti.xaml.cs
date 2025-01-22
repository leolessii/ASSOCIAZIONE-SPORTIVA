using AssociazioneSportiva;
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
    /// Logica di interazione per ModificaAtleti.xaml
    /// </summary>
    public partial class ModificaAtleti : Window
    {
        public Associazione associazione;
        public Specialita s;
        public ModificaAtleti(Associazione a)
        {
            InitializeComponent();
            associazione = a;
            dgAtleti.DataContext = null;
            dgAtleti.DataContext = associazione.RestituisciAtleti();
            CBSpecialità.ItemsSource = null;
            CBSpecialità.ItemsSource = associazione.Specialita;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtCercaAtleta_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_RimuoviAtleta_Click(object sender, RoutedEventArgs e)
        {
            associazione.Tesserati.Remove(dgAtleti.SelectedItem as Atleta);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBSpecialità.ItemsSource = null;
            CBSpecialità.ItemsSource = associazione.Specialita;
            s = CBSpecialità.SelectedItem as Specialita;
        }

        private void btn_ConfermaIscrizione_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AggiungiCertificato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ConfermaSpecialita_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            HomeAssociazione ha = new HomeAssociazione(associazione);
            ha.Show();
            this.Close();
        }

        private void txtAtleta_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
