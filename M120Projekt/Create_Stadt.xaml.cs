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
    /// Interaktionslogik für Create_Stadt.xaml
    /// </summary>
    public partial class Create_Stadt : Window
    {
        public Create_Stadt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Land_Detail land = new Land_Detail();
            land.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            Land_Detail land = new Land_Detail();
            land.Show();
        }
    }
}
