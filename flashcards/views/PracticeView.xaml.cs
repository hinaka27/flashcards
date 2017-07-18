﻿using System;
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

namespace Flashcards.views
{
    /// <summary>
    /// Logika interakcji dla klasy PracticeView.xaml
    /// </summary>
    public partial class PracticeView : UserControl
    {
        public PracticeView()
        {
            InitializeComponent();
        }

        private void startPractice_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).DataContext = new startPracticeView();
                }
            }
        }
    }
}
