using AssociazioneSportiva;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfAssociazione
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Associazione associazione;
        public MainWindow()
        {
            this.ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
            Associazione? associazioneLetta = LeggiImpostazioni();
            if (associazioneLetta != null)
            {
                associazione = associazioneLetta;
                LeggiAlteti();
                VaAHome();
            }
        }

        private void txtNome_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNome.Text = "";
        }

        private void txtQuota_GotFocus(object sender, RoutedEventArgs e)
        {
            txtQuota.Text = "";
        }

        private void btn_CreaAssociazione_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //inserire i dati dell'associazione
                associazione = new Associazione(txtNome.Text, Convert.ToInt32(txtQuota.Text), "Certificati");
                ScriviImpostazioni();
                VaAHome();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Associazione? LeggiImpostazioni()
        {
            try
            {
                Deserializzatore d = new Deserializzatore();
                return d.LeggiAssociazione();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void LeggiAlteti()
        {
            
            try
            {
                Deserializzatore d = new Deserializzatore();
                List<Atleta>? atleti = d.LeggiAtleti();
                if(atleti != null)
                {
                    for(int i = 0; i < atleti.Count; i++)
                    {
                        associazione.Tesserati.Add(atleti[i]);
                    }
                }
            }
            catch (Exception ex)
            {
             
            }
        }
        private void ScriviImpostazioni()
        {
            try
            {
                Serializzatore s = new Serializzatore();
                s.ScriviImpostazioni(txtNome.Text, Convert.ToInt32(txtQuota.Text), "Certificati");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VaAHome()
        {
            HomeAssociazione hm = new HomeAssociazione(associazione);
            hm.Show();
            this.Close();
        }
    }
}