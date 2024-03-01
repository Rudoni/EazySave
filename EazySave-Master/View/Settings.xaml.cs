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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        MainWindow m;
        ResourceManager rm;

        /// <summary>
        /// default constructor
        /// </summary>
        public Settings(MainWindow m)
        {

            InitializeComponent();
            this.m = m;
            this.rm = m.mv.resourceManager;

            languageComboBox.SelectedItem = (m.mv.lang == "en" ? enItem : frItem);
            logComboBox.SelectedItem = jsonItem;

            updateContent();


        }

        /// <summary>
        /// Called when the BackButton component is pressed
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            m.updatePriorityList();
            m.updateMaxSimultSize();

            m.view(EnumEasySaves.ViewNames.Menu);         
        }


        /// <summary>
        /// Called when the languageComboBox component selected item has changed
        /// </summary>
        private void languageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            m.mv.updateResourceLang(((ComboBoxItem)e.AddedItems[0]).Content.ToString().Substring(0, 2).ToLower());

            updateContent();

        }

        /// <summary>
        /// Called when the logComboBox component selected item has changed
        /// </summary>
        private void logComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem selectedItem = (ComboBoxItem)logComboBox.SelectedItem;

            m.mv.UpdateExtensionLog(logComboBox.Items.IndexOf(selectedItem) + 1);

        }

        /// <summary>
        /// Called when the addButton component is pressed
        /// </summary>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PriorityFileTxtBox.Text))
            {
               if(!m.priorityList.Contains("." + PriorityFileTxtBox.Text))
                {
                   PriorityFileListTxtBox.Items.Add("." + PriorityFileTxtBox.Text);
                   m.priorityList.Add("." + PriorityFileTxtBox.Text);
                }
                
                PriorityFileTxtBox.Clear();
                PriorityFileListTxtBox.Focus();
            }
        }


        /// <summary>
        /// Reloads the language resources call and the components of the view
        /// </summary>
        public void updateContent()
        {

            this.rm = m.mv.resourceManager;
            settingsTitle.Content = rm.GetString("Settings");
            backButton.Content = rm.GetString("Back");
            addButton.Content = rm.GetString("Add");
            languageLabel.Content = rm.GetString("Language");
            logFormatLabel.Content = rm.GetString("LogFormat");
            priorityFileExtensionLabel.Content = rm.GetString("PriorityFileExtension");
            maximumSizeLabel.Content = rm.GetString("MaxSimultaneousSize");
            KiloBytesLabel.Content = rm.GetString("KiloBytes");            

        }


    }
}
