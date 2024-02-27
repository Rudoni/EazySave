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
using System.Xml.Linq;
using Ookii.Dialogs.Wpf;
//using System.Windows.Forms;

namespace EazySave_Master.View
{
    /// <summary>
    /// Logique d'interaction pour CreateSave.xaml
    /// </summary>
    public partial class CreateSave : Page
    {

        MainWindow m;
        List<string> encryptList = new List<string>();

        /// <summary>
        /// default constructor
        /// </summary>
        public CreateSave(MainWindow m)
        {
            InitializeComponent();
            ValidateInputs();
            this.m = m;

        }

        /// <summary>
        /// Enable the createSaveButton component when all mandatory fields are filled
        /// </summary>
        private void ValidateInputs()
        {
            bool isAllFieldsFilled = !string.IsNullOrWhiteSpace(NameTxtBox.Text) &&
                                     !string.IsNullOrWhiteSpace(SourcePathTxtBox.Text) &&
                                     !string.IsNullOrWhiteSpace(DestinationPathTxtBox.Text) &&
                                     (totalRB.IsChecked == true || differentialRB.IsChecked == true);

            
            createSaveButton.IsEnabled = isAllFieldsFilled;
        }

        /// <summary>
        /// Called when the NameTxtBox component content has changed
        /// </summary>
        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        /// <summary>
        /// Called when the KeyTxtBox component content has changed
        /// </summary>
        private void Key_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        /// <summary>
        /// Called when totalRB or differentialRB component has been checked
        /// </summary>
        private void Type_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == totalRB)
            {
                differentialRB.IsChecked = false;
            }
            else if (sender == differentialRB)
            {
                totalRB.IsChecked = false;
            }
            ValidateInputs();
        }

        /// <summary>
        /// Called when the SourcePathTxtBox component content has changed
        /// </summary>
        private void Source_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        /// <summary>
        /// Called by path_Click methode to open the explorer window
        /// </summary>
        private void OpenFolderSource()
        {
            var dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                string selectedPath = dialog.SelectedPath;
                SourcePathTxtBox.Text = selectedPath;
            }
        }

        /// <summary>
        /// Called when the sourcePathButton component is pressed 
        /// </summary>
        private void path_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderSource();
        }

        /// <summary>
        /// Called when the DestinationPathTxtBox component content has changed
        /// </summary>
        private void Destination_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private void OpenFolderDest()
        {
            var dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                string selectedPath = dialog.SelectedPath;
                DestinationPathTxtBox.Text = selectedPath;
            }
        }

        /// <summary>
        /// Called when the destinationPathButton component content has changed
        /// </summary>
        private void path2_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDest();
        }

        /// <summary>
        /// Called when yesRB or noRB component has been checked
        /// </summary>
        private void Crypting_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == yesRB)
            {
                noRB.IsChecked = false;
                fileExtensionLabel.Visibility = Visibility.Visible;
                InputTxtBox.Visibility = Visibility.Visible;
                addButton.Visibility = Visibility.Visible;
                ItemsListTxtBox.Visibility = Visibility.Visible;
                encryptionKeyLabel.Visibility = Visibility.Visible;
                EncryptionKeyTxtBox.Visibility = Visibility.Visible;
            }
            else if (sender == noRB)
            {
                yesRB.IsChecked = false;
                fileExtensionLabel.Visibility = Visibility.Hidden;
                InputTxtBox.Visibility = Visibility.Hidden;
                addButton.Visibility = Visibility.Hidden;
                ItemsListTxtBox.Visibility = Visibility.Hidden;
                encryptionKeyLabel.Visibility = Visibility.Hidden;
                EncryptionKeyTxtBox.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when the addButton component is pressed
        /// </summary>
        private void AddExtensionButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputTxtBox.Text))
            {
                ItemsListTxtBox.Items.Add("." + InputTxtBox.Text);
                encryptList.Add("." + InputTxtBox.Text);
                InputTxtBox.Clear();
                InputTxtBox.Focus(); 
            }
        }

        /// <summary>
        /// Called when the createSaveButton component is pressed
        /// </summary>
        private void CreateSave_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTxtBox.Text;
            string sourcePath = SourcePathTxtBox.Text;
            string destinationPath = DestinationPathTxtBox.Text;
            
            string encryptKey = EncryptionKeyTxtBox.Text;
            string type;
            if(totalRB.IsChecked == true) { type = "1"; }
            else { type = "2"; }


            ModelView.ModelView.Instance.createSave(name, sourcePath, destinationPath, type, encryptList, encryptKey);

            m.view(EnumEasySaves.ViewNames.Menu);

        }

        /// <summary>
        /// Called when the backButton component is pressed
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.Menu);
        }

        /// <summary>
        /// Reloads the language resources call and the components of the view
        /// </summary>
        public void updateContent()
        {

            ResourceManager rm = m.mv.resourceManager;


            backButton.Content = rm.GetString("Back");
            nameLabel.Content = rm.GetString("Name");
            sourcePathLabel.Content = rm.GetString("SourcePath");
            targetPathLabel.Content = rm.GetString("TargetPath");
            saveTypeLabel.Content = rm.GetString("SaveType");
            totalRB.Content = rm.GetString("TotalSave");
            differentialRB.Content = rm.GetString("DifferentialSave");
            cryptingFileLabel.Content = rm.GetString("CryptingFile");
            yesRB.Content = rm.GetString("Yes");
            noRB.Content = rm.GetString("No");
            fileExtensionLabel.Content = rm.GetString("FileExtension");
            addButton.Content = rm.GetString("Add");
            encryptionKeyLabel.Content = rm.GetString("EncryptionKey");
            createSaveButton.Content = rm.GetString("CreateSave");

        }

    }
}
