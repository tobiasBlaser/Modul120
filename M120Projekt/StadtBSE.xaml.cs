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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für StadtBSE.xaml
    /// </summary>
    public partial class StadtBSE : UserControl
    {

        public string oldFlaeche;
        public string oldEinwohner;
        public bool? oldIsHauptstadt;

        private List<Data.Stadt> stadtListe;

        public StadtBSE()
        {
            InitializeComponent();
            datenVorbereiten();
        }

        private void datenVorbereiten()
        {
            stadtListe = new List<Data.Stadt>();

            Data.Stadt Bern = new Data.Stadt();
            Bern.StadtId = 1;
            Bern.StadtName = "Bern";
            Bern.IsHauptstadt = true;
            Bern.Flaeche = 52;
            Bern.Einwohnerzahl = 135000;
            stadtListe.Add(Bern);

            Data.Stadt Basel = new Data.Stadt();
            Basel.StadtId = 2;
            Basel.StadtName = "Basel";
            Basel.IsHauptstadt = false;
            Basel.Flaeche = 24;
            Basel.Einwohnerzahl = 170000;
            stadtListe.Add(Basel);

            Data.Stadt Luzern = new Data.Stadt();
            Luzern.StadtId = 3;
            Luzern.StadtName = "Luzern";
            Luzern.IsHauptstadt = false;
            Luzern.Flaeche = 37;
            Luzern.Einwohnerzahl = 82000;
            stadtListe.Add(Luzern);

            stadtName.Content = stadtListe[0].StadtName;
            flaecheInput.Text = stadtListe[0].Flaeche.ToString();
            einwohnerInput.Text = stadtListe[0].Einwohnerzahl.ToString();
            isHauptstadtInput.IsChecked = stadtListe[0].IsHauptstadt ? true : false;
        }

        private void editStadt(object sender, RoutedEventArgs e)
        {
            oldFlaeche = flaecheInput.Text;
            oldEinwohner = einwohnerInput.Text;
            oldIsHauptstadt = isHauptstadtInput.IsChecked;

            flaecheInput.IsEnabled = true;
            einwohnerInput.IsEnabled = true;
            isHauptstadtInput.IsEnabled = true;

            editStadtBtn.Visibility = Visibility.Hidden;
            deleteStadtBtn.Visibility = Visibility.Hidden;
            saveStadtBtn.Visibility = Visibility.Visible;
            cancleStadtBtn.Visibility = Visibility.Visible;
        }

        private void saveEdit(object sender, RoutedEventArgs e)
        {
            flaecheInput.IsEnabled = false;
            einwohnerInput.IsEnabled = false;
            isHauptstadtInput.IsEnabled = false;

            editStadtBtn.Visibility = Visibility.Visible;
            deleteStadtBtn.Visibility = Visibility.Visible;
            saveStadtBtn.Visibility = Visibility.Hidden;
            cancleStadtBtn.Visibility = Visibility.Hidden;
        }

        private void cancleEdit(object sender, RoutedEventArgs e)
        {
            flaecheInput.IsEnabled = false;
            einwohnerInput.IsEnabled = false;
            isHauptstadtInput.IsEnabled = false;

            editStadtBtn.Visibility = Visibility.Visible;
            deleteStadtBtn.Visibility = Visibility.Visible;
            saveStadtBtn.Visibility = Visibility.Hidden;
            cancleStadtBtn.Visibility = Visibility.Hidden;

             flaecheInput.Text = oldFlaeche;
             einwohnerInput.Text = oldEinwohner;
             isHauptstadtInput.IsChecked = oldIsHauptstadt;
        }

        private void deleteStadt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sind sie sich sicher, dass sie diese Stadt löschen wollen?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }
    }
}
