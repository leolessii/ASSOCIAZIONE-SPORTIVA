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
    /// Logica di interazione per specialitaAssociazione.xaml
    /// </summary>
    public partial class specialitaAssociazione : Window
    {
        public Associazione associazione;
        public specialitaAssociazione(Associazione a)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
            associazione = a;
            lstSpecialitàAssociazione.ItemsSource = null;
            lstSpecialitàAssociazione.ItemsSource = associazione.Specialita;
        }

        private void btn_ConfermaSpecialia_Click(object sender, RoutedEventArgs e)
        {
            Specialita s = new Specialita(txtNome.Text);
            associazione.Specialita.Add(s);
            lstSpecialitàAssociazione.ItemsSource = null;
            lstSpecialitàAssociazione.ItemsSource = associazione.Specialita;
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            HomeAssociazione ha = new HomeAssociazione(associazione);
            ha.Show();
            this.Close();
        }

        private void btn_RimuoviSpecialita_Click(object sender, RoutedEventArgs e)
        {
            associazione.Specialita.Remove(lstSpecialitàAssociazione.SelectedItem as Specialita);
            lstSpecialitàAssociazione.ItemsSource = null;
            lstSpecialitàAssociazione.ItemsSource = associazione.Specialita;
        }
    }
}
