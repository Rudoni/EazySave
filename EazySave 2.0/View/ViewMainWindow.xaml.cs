using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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

        /// <summary>
        /// default constructor
        /// </summary>
        public ViewMainWindow(MainWindow m)
        {
            InitializeComponent();
            this.m = m;
            updateContent();

        }

        /// <summary>
        /// Called when the CreateSaveButton component is pressed 
        /// </summary>
        private void Button_Click_CreateSave(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.CreateSaves);

        }

        /// <summary>
        /// Called when the RunSavebutton component is pressed 
        /// </summary>
        private void Button_Click_RunSave(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.RunSaves);
        }

        /// <summary>
        /// Called when the SettingsButton component is pressed 
        /// </summary>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.Settings);
        }

        /// <summary>
        /// Reloads the language resources call and the components of the view
        /// </summary>
        public void updateContent()
        {
            ResourceManager rm = this.m.mv.resourceManager;
            createSaveButton.Content = rm.GetString("CreateSave");
            runSaveButton.Content = rm.GetString("RunSave");
            settingsButton.Content = rm.GetString("Settings");
        }

    }
}
