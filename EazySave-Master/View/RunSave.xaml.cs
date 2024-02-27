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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            m.view(EnumEasySaves.ViewNames.Menu);
        }

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

                button.Click -= ExecuteButton_Click;
            }
        }

        public void updateContent()
        {
            ResourceManager rm = m.mv.resourceManager;
            ((GridView)ListOfSaves.View).Columns[1].Header = rm.GetString("Name");
            ((GridView)ListOfSaves.View).Columns[2].Header = rm.GetString("SourcePath");
            ((GridView)ListOfSaves.View).Columns[3].Header = rm.GetString("TargetPath");
        }

    }
}
