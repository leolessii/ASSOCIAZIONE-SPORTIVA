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
    /// Logica di interazione per AggiuntaTesserati.xaml
    /// </summary>
    public partial class AggiuntaTesserati : Window
    {
        public Associazione associazione;
        public List<string> ruoli;
        public AggiuntaTesserati(Associazione a)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.NoResize;
            associazione = a;
            ruoli = new List<string>();
            ruoli.Add("Atleta");
            ruoli.Add("Istruttore");
            ruoli.Add("Amministratore");
            lstRuoli.ItemsSource = ruoli;

            lstAtleti.ItemsSource = associazione.RestituisciAtleti();
            lstIstruttori.ItemsSource = associazione.RestituisciIstruttori();
            lstAmministratori.ItemsSource = associazione.RestituisciAmministratori();
        }
        private void AggiornaListe()
        {
            lstAtleti.ItemsSource = null;
            lstIstruttori.ItemsSource = null;
            lstAmministratori.ItemsSource =null;
            lstAtleti.ItemsSource = associazione.RestituisciAtleti();
            lstIstruttori.ItemsSource = associazione.RestituisciIstruttori();
            lstAmministratori.ItemsSource = associazione.RestituisciAmministratori();
        }
        private void btn_ConfermaIscrizione_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (lstRuoli.SelectedItem == ruoli[0]) {
                    DateTime dt = (DateTime)txtDataNascita.SelectedDate;
                    DateOnly d = DateOnly.FromDateTime(dt);
                    Atleta a = new Atleta(txtNome.Text, txtCognome.Text, txtNTelefono.Text, d);
                    associazione.Tesserati.Add(a);
                } else if (lstRuoli.SelectedItem == ruoli[1]) {
                    DateTime dt = (DateTime)txtDataNascita.SelectedDate;
                    DateOnly d = DateOnly.FromDateTime(dt);
                    Istruttore i = new Istruttore(txtNome.Text, txtCognome.Text, txtNTelefono.Text, d);
                    associazione.Tesserati.Add(i);
                } else if (lstRuoli.SelectedItem == ruoli[2]) {
                    DateTime dt = (DateTime)txtDataNascita.SelectedDate;
                    DateOnly d = DateOnly.FromDateTime(dt);
                    Amministratore a = new Amministratore(txtNome.Text, txtCognome.Text, txtNTelefono.Text, d);
                    associazione.Tesserati.Add(a);
                }
                AggiornaListe();
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            HomeAssociazione ha = new HomeAssociazione(associazione);
            ha.Show();
            this.Close();
        }
    }
}
