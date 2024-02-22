using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Resources;
using System.Reflection;
using EazySave_Master.Model;
using System;
using EazySave_Master.View;
using Newtonsoft.Json.Bson;

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
        ModelView.ModelView mv = ModelView.ModelView.Instance;
        ViewMainWindow viewMainWindow;
        public MainWindow()
        {
            InitializeComponent();
            createSave = new CreateSave(this);
            settings = new Settings(this);
            runsaves = new RunSave(this);
            viewMainWindow = new ViewMainWindow(this);
            this.Content = viewMainWindow;
        
        }

        public void view(string page)
        {
            switch (page)
            {
                case "menu":
                    this.Content = viewMainWindow;
                    break;
                case "create":
                    this.Content = createSave;
                    break;
                case "settings":
                    this.Content = settings;
                    break;
                case "runsaves":
                    this.Content = runsaves;
                    break;
            }
        }


    }
}