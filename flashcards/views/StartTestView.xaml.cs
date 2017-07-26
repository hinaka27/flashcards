﻿using Flashcards.viewmodel;
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

namespace Flashcards.views
{
    /// <summary>
    /// Logika interakcji dla klasy StartTestView.xaml
    /// </summary>
    public partial class StartTestView : UserControl
    {
        public StartTestView()
        {
            InitializeComponent();
        }
       
        string[] Pair = new string[2];
        

        private void next_Click(object sender, RoutedEventArgs e)
        {
            BoxWord2.IsEnabled = true;
            StartTestViewModel STVM = (StartTestViewModel)DataContext;
           
            if (STVM.checkedWord)
            {
                Pair = STVM.newPairTest();
                if (Pair[0] != null && Pair[1] != null)
                {
                    BoxWord1.Text = Pair[0];
                    WrongAnswer.Visibility = Visibility.Hidden;
                    answer.Visibility = Visibility.Hidden;
                    CorrectAnswer.Visibility = Visibility.Hidden;
                    BoxWord2.Text = null;
                }
                else
                {
                    STVM.EndTest = true;

                }
            }
            if (STVM.EndTest)
            {
                MessageBox.Show("You end the test!");
            }
        }

        private void check_Click_1(object sender, RoutedEventArgs e)
        {
            StartTestViewModel STVM = (StartTestViewModel)DataContext;
            if (BoxWord2.Text != null && STVM.EndTest != true)
            {               
                bool correct;
                correct = STVM.checkWords(Pair[1], BoxWord2.Text);
                countOfCorrectAnswer.Content = "Total correct:" + Convert.ToString(STVM.COCA);
                countOfWrongAnswer.Content = "Total wrong:" + Convert.ToString(STVM.COWA);
                if (correct == true)
                {
                    
                    CorrectAnswer.Visibility = Visibility.Visible;
                    
                    
                }
                else
                {
                    if (correct == false && STVM.StartTest){
                        answer.Content = "Correct answer is " + Pair[1];
                        WrongAnswer.Visibility = Visibility.Visible;
                        answer.Visibility = Visibility.Visible;
                        
                    }
                    else
                    {
                        answer.Content = "To start click next!";
                        answer.Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}
