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

namespace EazySave_Master.View
{
    /// <summary>
    /// Logique d'interaction pour ViewMainWindow.xaml
    /// </summary>
    public partial class ViewMainWindow : Page
    {

        MainWindow m;
        public ViewMainWindow(MainWindow m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void Button_Click_CreateSave(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.CreateSaves);

        }

        private void Button_Click_RunSave(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.RunSaves);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.Settings);
        }
    }
}
