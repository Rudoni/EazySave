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
using System.Collections.Generic;



namespace EazySave_Master.View
{
    /// <summary>
    /// Interaction logic for RunSave.xaml
    /// </summary>
    public partial class RunSave : Page
    {

        // Class representing a backup with its name and selection status.
        public class Sauvegarde
        {
            public string NomSauvegarde { get; set; }
            public bool IsSelected { get; set; }
        }

        public RunSave()
        {
            InitializeComponent();

            // Fill the backup list (example)
            List<Sauvegarde> sauvegardes = new List<Sauvegarde>
            {
                new Sauvegarde { NomSauvegarde = "Sauvegarde 1", IsSelected = false },
                new Sauvegarde { NomSauvegarde = "Sauvegarde 2", IsSelected = false },
                new Sauvegarde { NomSauvegarde = "Sauvegarde 3", IsSelected = false },
                new Sauvegarde { NomSauvegarde = "Sauvegarde 4", IsSelected = false },
                new Sauvegarde { NomSauvegarde = "Sauvegarde 5", IsSelected = false }
            };

            // Define the data source of the list.
            listBoxSauvegardes.ItemsSource = sauvegardes;
        }

        private void Button_Click_Run(object sender, RoutedEventArgs e)
        {
            // Iterate through the elements of the list and execute the selected backups.
            foreach (Sauvegarde sauvegarde in listBoxSauvegardes.ItemsSource)
            {
                if (sauvegarde.IsSelected)
                {

                    // Launch the backup...
                    // Here we add the code to execute the backup based on the backup name
                    // For example we can call a method to launch the backup using sauvegarde.NomSauvegarde
                }
            }
            // Display a message or perform other actions after launching the selected backups.
            MessageBox.Show("The selected backups have been successfully launched");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //Problem !
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
        }


    }
}
