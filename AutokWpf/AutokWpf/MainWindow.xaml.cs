using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace AutokWpf
{
    public partial class MainWindow : Window
    {
        private List<Auto> adatok = new List<Auto>();

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Autók";
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*";
            openFileDialog.Title = "Autók adatfájl megnyitása";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                 
                    File.ReadAllLines("autok.csv").Skip(1).ToList().ForEach(x => adatok.Add(new Auto(x)));

                    dgAutok.ItemsSource = null;
                    dgAutok.ItemsSource = adatok;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt a fájl betöltése közben: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void txtEvszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBox autoListBox = FindName("listBoxAutok") as ListBox;
            if (autoListBox != null)
            {
                autoListBox.Items.Clear();

                TextBox evTextBox = sender as TextBox;
                if (evTextBox != null && int.TryParse(evTextBox.Text, out int evszam))
                {
                    var szurtAutok = adatok.Where(a => a.GyartasiEv == evszam).ToList();

                    foreach (var auto in szurtAutok)
                    {
                        autoListBox.Items.Add($"{auto.Marka} {auto.Modell}");
                    }
                }
            }
        }

        private void btnBezár_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan ki szeretne lépni?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}