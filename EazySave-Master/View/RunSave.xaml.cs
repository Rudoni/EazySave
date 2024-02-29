using EazySave_Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EazySave_Master.View
{
    /// <summary>
    /// Logique d'interaction pour RunSave.xaml
    /// </summary>
    public partial class RunSave : Page
    {
        private MainWindow m;

        /// <summary>
        /// default constructor
        /// </summary>
        public RunSave()
        {
            InitializeComponent();
        }

        public RunSave(MainWindow mainWindow)
        {
            InitializeComponent();
            this.m = mainWindow;
            DataContext = m.mv.GetListSaves();
        }

        /// <summary>
        /// Called when the BackButton component is pressed
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.Menu);
        }

        /// <summary>
        /// Called when the languageComboBox component selected item has changed
        /// </summary>
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Called when the ExecuteButton component is pressed
        /// </summary>
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager rm = m.mv.resourceManager;

            // get number of save
            if (sender is Button button && button.DataContext is Save selectedSave)
            {
                string selectedNumber = selectedSave.number.ToString();

                MessageBoxResult result = MessageBox.Show(rm.GetString("PopupConfirm"), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    // run save
                    m.mv.runSavesFromNumbers(selectedNumber);

                    button.Click -= ExecuteButton_Click;

                    MessageBox.Show(rm.GetString("PopupFinished"), "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // get number of save
            if (sender is Button button && button.DataContext is Save selectedSave)
            {

                ResourceManager rm = m.mv.resourceManager;

                MessageBoxResult result = MessageBox.Show(rm.GetString("PopupConfirmDelete"), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {

                    int selectedNumber = selectedSave.number;
                    m.mv.deleteSave(selectedNumber);

                    button.Click -= DeleteButton_Click;

                }
            }
        }

        public void updateContent()
        {
            ResourceManager rm = m.mv.resourceManager;
            ((GridView)ListOfSaves.View).Columns[0].Header = rm.GetString("Name");
            ((GridView)ListOfSaves.View).Columns[1].Header = rm.GetString("SourcePath");
            ((GridView)ListOfSaves.View).Columns[2].Header = rm.GetString("TargetPath");
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void progressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
