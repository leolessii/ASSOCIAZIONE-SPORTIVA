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
    /// Logica di interazione per ModificaIstruttore.xaml
    /// </summary>
    public partial class ModificaIstruttore : Window
    {
        public Associazione associazione;
        public ModificaIstruttore(Associazione a)
        {
            InitializeComponent();
            associazione = a;
        }
    }
}
