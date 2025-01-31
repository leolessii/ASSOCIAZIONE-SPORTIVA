﻿using AssociazioneSportiva;
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
        string cerca;
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
                    MessageBox.Show(s);
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
            int year = Convert.ToInt32(DatePicker.Text.Split('/')[0]);
            int month = Convert.ToInt32(DatePicker.Text.Split('/')[1].Split('/')[0]);
            int day = Convert.ToInt32(DatePicker.Text.Split('/')[1].Split('/')[0]);
            DateOnly d = new DateOnly(year, month, day);
            Tessera t = new Tessera();
            Atleta a = new Atleta(txtNome.Text, txtCognome.Text, txtNumerotelefono.Text, d, t);
            associazione.Tesserati.Add(a);
            dgAtleti.ItemsSource = null;
            dgAtleti.ItemsSource = associazione.RestituisciAtleti();

            Serializzatore s = new Serializzatore();
            s.ScriviAtleta(a, Formato.Xaml);
        }

        private void btn_AggiungiCertificato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ConfermaSpecialita_Click(object sender, RoutedEventArgs e)
        {
            if(dgAtleti.SelectedItem != null && CBSpecialità.SelectedItem != null)
            {
                
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
    }
}
