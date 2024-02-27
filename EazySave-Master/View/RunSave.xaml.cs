using EazySave_Master.Model;
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

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            // get number of save
            if (sender is Button button && button.DataContext is Save selectedSave)
            {
                string selectedNumber = selectedSave.number.ToString();

                // run save
                m.mv.runSavesFromNumbers(selectedNumber);
            }
        }

        /// <summary>
        /// Reloads the language resources call and the components of the view
        /// </summary>
        public void updateContent()
        {
            ResourceManager rm = m.mv.resourceManager;
            ((GridView)ListOfSaves.View).Columns[1].Header = rm.GetString("Name");
            ((GridView)ListOfSaves.View).Columns[2].Header = rm.GetString("SourcePath");
            ((GridView)ListOfSaves.View).Columns[3].Header = rm.GetString("TargetPath");
        }

    }
}
