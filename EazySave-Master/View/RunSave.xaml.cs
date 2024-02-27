﻿using EazySave_Master.Model;
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
            }
        }

    }
}
