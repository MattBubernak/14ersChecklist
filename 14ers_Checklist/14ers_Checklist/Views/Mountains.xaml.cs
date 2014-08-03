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
using System.Diagnostics; 

namespace _14ers_Checklist.Views
{
    public partial class Mountains : PhoneApplicationPage
    {
        const string CONFIRM_UNCHECK = "Are you sure you want to uncheck this mountain? Your ascent info will be lost";
        const string CONFIRM_TITLE = "Confirm Uncheck";
        public ChecklistViewModel checklistViewModel = null; 
        public Mountains()
        {
            InitializeComponent();
            this.DataContext = ChecklistViewModel.get_instance();
            checklistViewModel = ChecklistViewModel.get_instance(); 
        }

        private void MountainListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine("entering long list selecter changed");
            int selectedIndex = MountainSelector.ItemsSource.IndexOf(MountainSelector.SelectedItem as MountainViewModel);
            if (selectedIndex >= 0)
            {
                //exerciseInstanceHandler.ExerciseInstance = WorkoutLongListSelector.SelectedItem as ExerciseInstance; 
                NavigationService.Navigate(new Uri("/Views/Mountain.xaml?selectedIndex=" + selectedIndex, UriKind.Relative));
                //reset the selector so that the same mountain can be selected again. 
                MountainSelector.SelectedItem = null;
            }
            //Debug.WriteLine("leavings long list selecter changed");

        }

        private void CheckBox_Hit(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("entering checkbox_hit");

            MountainViewModel clicked = ((sender as CheckBox).DataContext as MountainViewModel);
            Debug.WriteLine(clicked.Name); 
            /*
            if (clicked.Check) // ask if they really want to uncheck the mountain
            {

                MessageBoxResult message = Show_Message(CONFIRM_UNCHECK,CONFIRM_TITLE + " " + clicked.Name); 
                if (message == MessageBoxResult.OK)
                {
                    clicked.Check = false;
                    (sender as CheckBox).IsChecked = false; //maybe this could be a notify propertychanged
                    //Debug.WriteLine(clicked.Name + "now should be: false and is: " + clicked.Check);
                }
                else
                {
                    clicked.Check = true;
                    (sender as CheckBox).IsChecked = true; //maybe this could be a notify propertychanged
                    //Debug.WriteLine(clicked.Name + "now should be: true and is: " + clicked.Check);

                }
            }
            else //navigate to the mountain page 
            {
                clicked.Check = true;
                Debug.WriteLine(clicked.Name + "now should be: true and is: " + clicked.Check);

                //(sender as CheckBox).IsChecked = true; //maybe this could be a notify propertychanged

            }
             */
            if (clicked.Check)
            {
                clicked.Check = false;
                (sender as CheckBox).IsChecked = false;
                Debug.WriteLine((sender as CheckBox).IsChecked);

            }
            else
            {
                clicked.Check = true;
                (sender as CheckBox).IsChecked = true;
                Debug.WriteLine((sender as CheckBox).IsChecked);

            }
            checklistViewModel.NotifyProperties();
            Debug.WriteLine("exiting checkbox_hit");
        }
        private MessageBoxResult Show_Message(string message, string messageTitle)
        {
            MessageBoxResult result = MessageBox.Show(message, messageTitle, MessageBoxButton.OKCancel);
            return result; 
        }

        private void About(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/About.xaml", UriKind.Relative));
        }

       


    }
}