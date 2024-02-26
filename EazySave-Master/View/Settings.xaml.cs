using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EazySave_Master.View
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        MainWindow m;
        string lang;
        ResourceManager rm;
        public Settings(MainWindow m)
        {
            
            InitializeComponent();
            this.m = m;
            this.lang = m.mv.lang;
            this.rm = m.mv.resourceManager;

            languageComboBox.SelectedItem = (lang == "en" ? enItem : frItem);
            logComboBox.SelectedItem = jsonItem;

            updateContent();


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.Menu);
        }

        private void languageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            m.mv.updateResourceLang(((ComboBoxItem)e.AddedItems[0]).Content.ToString().Substring(0, 2).ToLower());
            
            updateContent();

        }

        public void updateContent()
        {
            this.rm = m.mv.resourceManager;
            settingsTitle.Content = rm.GetString("Settings");
            backButton.Content = rm.GetString("Back");
            languageLabel.Content = rm.GetString("Language");
            logFormatLabel.Content = rm.GetString("LogFormat");

        }

        private void logComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)logComboBox.SelectedItem;

            m.mv.UpdateExtensionLog(logComboBox.Items.IndexOf(selectedItem)+1);
            

        }
    }
}
