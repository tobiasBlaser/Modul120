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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Land_Detail.xaml
    /// </summary>
    public partial class Land_Detail : Window
    {

        public string oldGruendungsJahr;
        public string oldFlaeche;
        public string oldEinwohner;
        public string oldSprache;

        public Land_Detail()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            zustandLbl.Content = "Zustand: Löschen";
            if (MessageBox.Show("Sind sie sich sicher, dass sie dieses Land löschen wollen?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) {
                Hide();
            }
            zustandLbl.Content = "Zustand: Ansicht";
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            oldGruendungsJahr = gruendungsJahrInput.Text;
            oldFlaeche = flaecheInput.Text;
            oldEinwohner = einwohnerInput.Text;
            oldSprache = spracheInput.Text;

            gruendungsJahrInput.IsEnabled = true;
            flaecheInput.IsEnabled = true;
            einwohnerInput.IsEnabled = true;
            spracheInput.IsEnabled = true;

            createCityButton.Visibility = Visibility.Hidden;
            editButton.Visibility = Visibility.Hidden;
            deleteButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Visible;
            cancleButton.Visibility = Visibility.Visible;

            zustandLbl.Content = "Zustand: Bearbeiten";
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            gruendungsJahrInput.IsEnabled = false;
            flaecheInput.IsEnabled = false;
            einwohnerInput.IsEnabled = false;
            spracheInput.IsEnabled = false;

            createCityButton.Visibility = Visibility.Visible;
            editButton.Visibility = Visibility.Visible;
            deleteButton.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Hidden;
            cancleButton.Visibility = Visibility.Hidden;

             gruendungsJahrInput.Text = oldGruendungsJahr;
             flaecheInput.Text = oldFlaeche;
             einwohnerInput.Text = oldEinwohner;
             spracheInput.Text = oldSprache;

            zustandLbl.Content = "Zustand: Ansicht";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            gruendungsJahrInput.IsEnabled = false;
            flaecheInput.IsEnabled = false;
            einwohnerInput.IsEnabled = false;
            spracheInput.IsEnabled = false;

            createCityButton.Visibility = Visibility.Visible;
            editButton.Visibility = Visibility.Visible;
            deleteButton.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Hidden;
            cancleButton.Visibility = Visibility.Hidden;

            zustandLbl.Content = "Zustand: Ansicht";
        }

        private void createCityButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Create_Stadt stadt = new Create_Stadt();
            stadt.Show();
        }
    }
}
