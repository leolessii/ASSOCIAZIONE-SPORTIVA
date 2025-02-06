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
using System.Xml.Serialization;

namespace WpfAssociazione
{
    /// <summary>
    /// Logica di interazione per ModificaAtleti.xaml
    /// </summary>
    public partial class ModificaAtleti : Window
    {
        public Associazione associazione;
        public Specialita s;
        string cerca;
        int counter = -1;
        public ModificaAtleti(Associazione a)
        {
            InitializeComponent();
            associazione = a;
            dgAtleti.ItemsSource = null;
            dgAtleti.ItemsSource = associazione.RestituisciAtleti();
            CBSpecialità.ItemsSource = null;
            CBSpecialità.ItemsSource = associazione.Specialita;
            cerca = txtCercaAtleta.Text; 
        }

        private void txtCercaAtleta_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach(Atleta a in dgAtleti.Items)
            {
                if(CorrispondenzaAtleta(txtCercaAtleta.Text, a))
                {
                    dgAtleti.ItemsSource = null;
                    dgAtleti.Items.Add(a);
                }
                else
                {
                    string s = "Nessuna Corrispondenza";
                    System.Windows.Forms.MessageBox.Show(s);
                    txtCercaAtleta.Text = cerca;
                    dgAtleti.ItemsSource = null;
                    dgAtleti.ItemsSource = associazione.RestituisciAtleti();
                }
            }

            if(string.IsNullOrEmpty(txtCercaAtleta.Text))
            {
                txtCercaAtleta.Text = cerca;
                dgAtleti.ItemsSource = null;
                dgAtleti.ItemsSource = associazione.RestituisciAtleti();
            }
        }

        public bool CorrispondenzaAtleta(string s, Atleta a)
        {
            foreach(Char c in s)
            {
                if(c == a.Nome[0] || c == a.Cognome[0])
                {
                    return true;
                }
            }
            return false;
        }

        private void btn_RimuoviAtleta_Click(object sender, RoutedEventArgs e)
        {
            associazione.Tesserati.Remove(dgAtleti.SelectedItem as Atleta);
            dgAtleti.ItemsSource = null;
            dgAtleti.ItemsSource = associazione.RestituisciAtleti();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBSpecialità.ItemsSource = null;
            CBSpecialità.ItemsSource = associazione.Specialita;
            s = CBSpecialità.SelectedItem as Specialita;
        }

        private void btn_ConfermaIscrizione_Click(object sender, RoutedEventArgs e)
        {
            DateOnly anno = DateOnly.FromDateTime(Convert.ToDateTime(DatePicker.SelectedDate));
            counter += 1;
            Tessera t = new Tessera(counter);
            Atleta a = new Atleta(txtNome.Text, txtCognome.Text, txtNumerotelefono.Text, anno, t);
            associazione.Tesserati.Add(a);
            dgAtleti.ItemsSource = null;
            dgAtleti.ItemsSource = associazione.RestituisciAtleti();
        }

        private void btn_AggiungiCertificato_Click(object sender, RoutedEventArgs e)
        {
            if(dgAtleti.SelectedItem != null)
            {
                OpenFolderDialog dialog = new OpenFolderDialog();
                string path = dialog.ShowDialog().ToString();
                if(!string.IsNullOrEmpty(path))
                {
                    foreach (Atleta a in associazione.RestituisciAtleti())
                    {
                        if (a == dgAtleti.SelectedItem)
                        {
                            a.CertificatoMedico!.CaricaFoto(path, a.Nome, associazione.PercorsoCertificati);
                        }
                    }
                }
            }else
            {
                System.Windows.Forms.MessageBox.Show("Atleta non selezionato");
            }
        }

        private void btn_ConfermaSpecialita_Click(object sender, RoutedEventArgs e)
        {
            if(dgAtleti.SelectedItem != null && CBSpecialità.SelectedItem != null)
            {
                foreach(Atleta a in associazione.RestituisciAtleti())
                {
                    if(a == dgAtleti.SelectedItem)
                    {
                        DateTime dateTime = DateTime.Now;
                        a.AggiungiSpecialita(CBSpecialità.SelectedItem as Specialita, (int)dateTime.Year);
                    }
                }
            }
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

        private void btn_InviaDati_Click(object sender, RoutedEventArgs e)
        {
            Serializzatore s = new Serializzatore();
            s.ScriviAtleti(Formato.Xaml, associazione);
        }
    }
}
