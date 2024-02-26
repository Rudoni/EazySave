﻿using System.Text;
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