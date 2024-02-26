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
        public CreateSave(MainWindow m)
        {
            InitializeComponent();
            ValidateInputs();
            this.m = m;

        }
        // We can only create save if all fields filled
        private void ValidateInputs()
        {
            bool isAllFieldsFilled = !string.IsNullOrWhiteSpace(Name.Text) &&
                                     !string.IsNullOrWhiteSpace(SourcePath.Text) &&
                                     !string.IsNullOrWhiteSpace(DestinationPath.Text) &&
                                     (totalRB.IsChecked == true || differentialRB.IsChecked == true);

            
            createSaveButton.IsEnabled = isAllFieldsFilled;
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private void Key_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

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

        private void Source_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private void OpenFolderSource()
        {
            var dialog = new VistaFolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                string selectedPath = dialog.SelectedPath;
                SourcePath.Text = selectedPath;
            }
        }
        private void path_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderSource();
        }


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
                DestinationPath.Text = selectedPath;
            }
        }

        private void path2_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDest();
        }

        private void Crypting_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == yesRB)
            {
                noRB.IsChecked = false;
                fileExtensionLabel.Visibility = Visibility.Visible;
                InputTextBox.Visibility = Visibility.Visible;
                addButton.Visibility = Visibility.Visible;
                ItemsListBox.Visibility = Visibility.Visible;
                encryptionKeyLabel.Visibility = Visibility.Visible;
                EncryptionKey.Visibility = Visibility.Visible;
            }
            else if (sender == noRB)
            {
                yesRB.IsChecked = false;
                fileExtensionLabel.Visibility = Visibility.Hidden;
                InputTextBox.Visibility = Visibility.Hidden;
                addButton.Visibility = Visibility.Hidden;
                ItemsListBox.Visibility = Visibility.Hidden;
                encryptionKeyLabel.Visibility = Visibility.Hidden;
                EncryptionKey.Visibility = Visibility.Hidden;
            }
        }

        private void AddExtentionButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                ItemsListBox.Items.Add("." + InputTextBox.Text);
                encryptList.Add("." + InputTextBox.Text);
                InputTextBox.Clear();
                InputTextBox.Focus(); 
            }
        }

        private void CreateSave_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string sourcePath = SourcePath.Text;
            string destinationPath = DestinationPath.Text;
            
            string encryptKey = EncryptionKey.Text;
            string type;
            if(totalRB.IsChecked == true) { type = "1"; }
            else { type = "2"; }


            ModelView.ModelView.Instance.createSave(name, sourcePath, destinationPath, type, encryptList, encryptKey);

            m.view(EnumEasySaves.ViewNames.Menu);

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.Menu);
        }

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
