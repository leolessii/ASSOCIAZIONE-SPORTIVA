using AssociazioneSportiva;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            try {
                //inserire il nome dell'associazione
                associazione = new Associazione(txtNome.Text, Convert.ToInt32(txtQuota.Text));
                HomeAssociazione hm = new HomeAssociazione(associazione);
                hm.Show();
                this.Close();
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }    
        }
    }
}