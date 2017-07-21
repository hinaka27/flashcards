﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flashcards.viewmodel
{
    class testerTextBox
    {
        public string Text { get; set; }
        public string Text2 { get; set; }
        public testerTextBox(string str,string str2)
        {
            Text = str;
            Text2 = str2;
        }
    }

    class editSelectedListViewModel
    {
        static public ObservableCollection<testerTextBox> ListOfElements;

        public editSelectedListViewModel()
        {
            if (ListOfElements == null)
            {
                ObservableCollection<testerTextBox> items = new ObservableCollection<testerTextBox>();
                /*items.Add(new testerTextBox("item 1", "abc"));
                items.Add(new testerTextBox("item 2", "def"));
                items.Add(new testerTextBox("item 3", "ghi"));*/
                ListOfElements = items;
            }

        }

        public void tryIt(ListView LV)
        {

            LV.ItemsSource = ListOfElements;
        }

        public void readItems(ListView LV)
        {
            ListOfElements.Clear();

            foreach(testerTextBox item in LV.ItemsSource)
            {
                ListOfElements.Add(new testerTextBox(item.Text, item.Text2));
            }
            ListOfElements.Add(new testerTextBox("itemtested", "itemtested 2"));
            tryIt(LV);
        }

        public void addNewItem(ListView LV, string str1, string str2)
        {
            //ListOfElements.Clear();

            /*if (LV.ItemsSource != null)
            {
                foreach (testerTextBox item in LV.ItemsSource)
                {
                    ListOfElements.Add(new testerTextBox(item.Text, item.Text2));
                }
            }*/
            ListOfElements.Add(new testerTextBox(str1, str2));
            tryIt(LV);
        }

        public void removeItem(ListView LV, int index)
        {
            ListOfElements.RemoveAt(index);
            tryIt(LV);
        }

    }
}
