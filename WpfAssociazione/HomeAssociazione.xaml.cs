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
            lbl4.Content = "Associazione" + associazione.Nome;
            lstAtleti.ItemsSource = associazione.RestituisciAtleti();
            lstIstruttori.ItemsSource = associazione.RestituisciIstruttori();
            lstAmministratori.ItemsSource = associazione.RestituisciAmministratori();

            btn_ModificaSpecialiàTesserato.Visibility = Visibility.Collapsed;
            tesseratoSelezionato = null;
        }
        private void AggiornaListe()
        {
            lstAtleti.ItemsSource = null;
            lstIstruttori.ItemsSource = null;
            lstAmministratori.ItemsSource = null;
            lstAtleti.ItemsSource = associazione.RestituisciAtleti();
            lstIstruttori.ItemsSource = associazione.RestituisciIstruttori();
            lstAmministratori.ItemsSource = associazione.RestituisciAmministratori();
        }

        private void btn_AggiungiTesserato_Click(object sender, RoutedEventArgs e)
        {
            AggiuntaTesserati ag = new AggiuntaTesserati(associazione);
            ag.Show();
            this.Close();
        }

        private void lstAtleti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstAtleti.SelectedItem != null)
            {
                lstAmministratori.SelectedItem = null;
                lstIstruttori.SelectedItem = null;
                btn_ModificaSpecialiàTesserato.Visibility = Visibility.Visible;
                Atleta a = lstAtleti.SelectedItem as Atleta;
                lbl5.Content = $"{a.Nome} \n {a.Cognome} \n {a.NumeroTelefono} \n {a.DataNascita}";
                tesseratoSelezionato = a as Tesserato;
            }
            
        }

        private void lstIstruttori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstIstruttori.SelectedItem != null)
            {
                lstAmministratori.SelectedItem = null;
                lstAtleti.SelectedItem = null;
                btn_ModificaSpecialiàTesserato.Visibility = Visibility.Visible;
                Istruttore i = lstIstruttori.SelectedItem as Istruttore;
                lbl5.Content = $"{i.Nome} \n {i.Cognome} \n {i.NumeroTelefono} \n {i.DataNascita}";
                tesseratoSelezionato = i as Tesserato;
            }
            
        }

        private void lstAmministratori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstAmministratori.SelectedItem != null)
            {
                lstAtleti.SelectedItem = null;
                lstIstruttori.SelectedItem = null;
                btn_ModificaSpecialiàTesserato.Visibility = Visibility.Collapsed;
                Amministratore am = lstAmministratori.SelectedItem as Amministratore;
                lbl5.Content = $"{am.Nome} \n {am.Cognome} \n {am.NumeroTelefono} \n {am.DataNascita}";
                tesseratoSelezionato = am as Tesserato;
            }  
        }

        private void btn_RimuoviTesserato_Click(object sender, RoutedEventArgs e)
        {
            try {
                associazione.RimuoviTesserato(tesseratoSelezionato);
                AggiornaListe();
                tesseratoSelezionato = null;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message );
            }
            
        }

        private void btn_ModificaSpecialiàTesserato_Click(object sender, RoutedEventArgs e)
        {
            if(tesseratoSelezionato is IGestioneSpecialita) {
                SpecialitaTesserato st = new SpecialitaTesserato(associazione, tesseratoSelezionato as IGestioneSpecialita);
                st.Show();
                this.Close();
            } 
        }

        private void btn_AggiungiCertificato_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (tesseratoSelezionato is Istruttore || tesseratoSelezionato is Atleta) {
                    OpenFileDialog fd = new OpenFileDialog();
                    bool? successo = fd.ShowDialog();
                    if (successo == true) {
                        string percorso = fd.FileName;
                        Certificato certificato;
                        if (tesseratoSelezionato is Istruttore) certificato = (tesseratoSelezionato as Istruttore).CertificatoIstruttore;
                        else certificato = (tesseratoSelezionato as Atleta).CertificatoMedico;
                        certificato.CaricaFoto(percorso,tesseratoSelezionato.Nome+tesseratoSelezionato.Cognome+tesseratoSelezionato.Tessera.Code.ToString());
                        MessageBox.Show("certificato caricato!");
                    }
                }      
            }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ModificaSpecialiàAssociazione_Click(object sender, RoutedEventArgs e)
        {
            specialitaAssociazione sa = new specialitaAssociazione(associazione);
            sa.Show();
            this.Close();
        }


    }
}
