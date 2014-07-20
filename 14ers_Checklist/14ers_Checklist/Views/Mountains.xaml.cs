using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _14ers_Checklist.ViewModels; 

namespace _14ers_Checklist.Views
{
    public partial class Mountains : PhoneApplicationPage
    {
        const string CONFIRM_UNCHECK = "Are you sure you want to uncheck this mountain? Your ascent info will be lost";
        const string CONFIRM_TITLE = "Confirm Uncheck";
        public Mountains()
        {
            InitializeComponent();
            this.DataContext = ChecklistViewModel.getInstance(); 
        }

        private void MountainListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Hit(object sender, RoutedEventArgs e)
        {
            MountainViewModel clicked = ((sender as CheckBox).DataContext as MountainViewModel);
            if (clicked.Check) // ask if they really want to uncheck the mountain
            {

                MessageBoxResult message = Show_Message(CONFIRM_UNCHECK,CONFIRM_TITLE + " " + clicked.Name); 
                if (message == MessageBoxResult.OK)
                {
                    clicked.Check = false;
                }
                else
                {
                    clicked.Check = true;
                    (sender as CheckBox).IsChecked = true; //maybe this could be a notify propertychanged

                }
            }
            else //navigate to the mountain page 
            {
                clicked.Check = true; 
            }

        }
        private MessageBoxResult Show_Message(string message, string messageTitle)
        {
            MessageBoxResult result = MessageBox.Show(message, messageTitle, MessageBoxButton.OKCancel);
            return result; 
        }

    }
}