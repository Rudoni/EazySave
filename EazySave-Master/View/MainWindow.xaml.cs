using System.Text;
using System.Windows;

namespace EazySave_Master.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CreateSave createSave;
        Settings settings;
        RunSave runsaves;
        public ModelView.ModelView mv { set; get; } = ModelView.ModelView.Instance;
        ViewMainWindow viewMainWindow;

        private static Mutex mutex = null;

        public MainWindow()
        {
            const string appName = "EazySave_Master";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("App already running");
                Application.Current.Shutdown();
                return;
            }

            InitializeComponent();
            createSave = new CreateSave(this);
            settings = new Settings(this);
            runsaves = new RunSave(this);
            viewMainWindow = new ViewMainWindow(this);
            this.Content = viewMainWindow;

            //manage load of saves already existing
            mv.LoadSavesFromFile();

            //manage closing of the app
            Closing += MainWindow_Closing;
        }

        /// <summary>
        /// when the app close, saves are written in file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            mv.WriteSavesToFile();
        }

        public void view(EnumEasySaves.ViewNames page)
        {
            switch (page)
            {
                case EnumEasySaves.ViewNames.Menu:
                    this.Content = viewMainWindow;
                    break;
                case EnumEasySaves.ViewNames.CreateSaves:
                    this.Content = createSave;
                    break;
                case EnumEasySaves.ViewNames.Settings:
                    this.Content = settings;
                    break;
                case EnumEasySaves.ViewNames.RunSaves:
                    this.Content = runsaves;
                    break;
            }
        }


    }
}