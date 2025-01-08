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
    /// Logica di interazione per SpecialitaTesserato.xaml
    /// </summary>
    public partial class SpecialitaTesserato : Window
    {
        public Associazione associazione;
        public IGestioneSpecialita tesserato;
        public SpecialitaTesserato(Associazione a, IGestioneSpecialita tes)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
            associazione = a;
            tesserato = tes;
            lstSpecialitaTesserato.ItemsSource = null;
            lstSpecialitaTesserato.ItemsSource = tesserato.GetSpecialitaDiStagione(DateTime.Now.Year);
        }

        private void btn_ConfermaSpecialia_Click(object sender, RoutedEventArgs e)
        {
            Specialita s = new Specialita(txtNome.Text);
            tesserato.AggiungiSpecialita(s, DateTime.Now.Year);
            lstSpecialitaTesserato.ItemsSource = null;
            lstSpecialitaTesserato.ItemsSource = tesserato.GetSpecialitaDiStagione(DateTime.Now.Year);
        }

        private void btn_RimuoviSpecialita_Click(object sender, RoutedEventArgs e)
        {
            tesserato.RimuoviSpecialita(lstSpecialitaTesserato.SelectedItem as Specialita,DateTime.Now.Year);
            lstSpecialitaTesserato.ItemsSource = null;
            lstSpecialitaTesserato.ItemsSource = tesserato.GetSpecialitaDiStagione(DateTime.Now.Year);
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            HomeAssociazione ha = new HomeAssociazione(associazione);
            ha.Show();
            this.Close();
        }
    }
}
