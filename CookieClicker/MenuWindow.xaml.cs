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
using System.IO;

namespace CookieClicker
{
    /// <summary>
    /// Logika interakcji dla klasy MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();

            CheckContinuePossibility();
        }

        public void CheckContinuePossibility()
        {
            if (File.Exists("buildings.json") && File.Exists("upgrades.json") && File.Exists("cookie.json"))
            {
                MenuContinueButton.IsEnabled = true;
            }
            else
            {
                MenuContinueButton.IsEnabled = false;
            }
        }

        private void MenuContinueButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(this, true);
            mainWindow.Show();
            this.Hide();
        }

        private void MenuNewGameButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(this, false);
            mainWindow.Show();
            this.Hide();
        }
    }
}
