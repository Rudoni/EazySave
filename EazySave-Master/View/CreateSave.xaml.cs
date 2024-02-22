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
                                     (Total.IsChecked == true || Differential.IsChecked == true);

            
            CreateSaveButton.IsEnabled = isAllFieldsFilled;
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private void Type_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == Total)
            {
                Differential.IsChecked = false;
            }
            else if (sender == Differential)
            {
                Total.IsChecked = false;
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
            if (sender == Yes)
            {
                No.IsChecked = false;
                FileExtentionName.Visibility = Visibility.Visible;
                InputTextBox.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
                ItemsListBox.Visibility = Visibility.Visible;
            }
            else if (sender == No)
            {
                Yes.IsChecked = false;
                FileExtentionName.Visibility = Visibility.Hidden;
                InputTextBox.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;
                ItemsListBox.Visibility = Visibility.Hidden;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                ItemsListBox.Items.Add(InputTextBox.Text);
                InputTextBox.Clear();
                InputTextBox.Focus(); 
            }
        }

        private void CreateSave_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string sourcePath = SourcePath.Text;
            string destinationPath = DestinationPath.Text;
            List<string> encryptList = new List<string>();
            string encryptKey = "XOR";
            string type;
            if(Total.IsChecked == true) { type = "1"; }
            else { type = "2"; }


            ModelView.ModelView.Instance.createSave(name, sourcePath, destinationPath, type, encryptList, encryptKey);

            m.view("menu");

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            m.view("menu");
        }
    }
}
