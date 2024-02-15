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
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Resources;
using System.Reflection;
using EazySave_Master.Model;
using System;
using EazySave_Master.View;

namespace EazySave_Master.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        
        }

        private void Button_Click_CreateSave(object sender, RoutedEventArgs e)
        {
             MainFrame.Navigate(new CreateSave());

            // Hidden Main Frame
            (sender as Button).Visibility = Visibility.Collapsed;
            RunSave.Visibility = Visibility.Collapsed;

        }

        private void Button_Click_RunSave(object sender, RoutedEventArgs e)
        {
            
        }
    }
}