﻿using System.Globalization;
using System.Reflection;
using System.Resources;
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

        /// <summary>
        /// default constructor
        /// </summary>
        public MainWindow()
        {
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

        /// <summary>
        /// Called to change the current view and to reload its components
        /// </summary>
        /// <param name="page"></param>
        public void view(EnumEasySaves.ViewNames page)
        {
            switch (page)
            {
                case EnumEasySaves.ViewNames.Menu:
                    viewMainWindow.updateContent();
                    this.Content = viewMainWindow;
                    
                    break;
                case EnumEasySaves.ViewNames.CreateSaves:
                    createSave.updateContent();
                    this.Content = createSave;
                    break;
                case EnumEasySaves.ViewNames.Settings:
                    settings.updateContent();
                    this.Content = settings;
                    break;
                case EnumEasySaves.ViewNames.RunSaves:
                    runsaves.updateContent();
                    this.Content = runsaves;
                    break;
            }
        }

        


    }
}