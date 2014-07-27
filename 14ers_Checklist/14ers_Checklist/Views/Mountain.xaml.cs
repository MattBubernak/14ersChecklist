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
using Coding4Fun.Toolkit.Controls; 

namespace _14ers_Checklist.Views
{
    public partial class Mountain : PhoneApplicationPage
    {
        public Mountain()
        {
            InitializeComponent();
            DataContext = null;
            UpdatePanoramaAppBar(0);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedIndex", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    DataContext = ChecklistViewModel.get_instance().mountains[index];
                }
            }
        }

        private void panoramaControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentPanoramaIndex = panoramaControl.SelectedIndex;
            UpdatePanoramaAppBar(currentPanoramaIndex);
        }

        private void UpdatePanoramaAppBar(int index)
        {
            //create a new application bar
            ApplicationBar = new ApplicationBar();

            switch (index)
            {
                case 0:
                    
                    break;
                case 1:
                    //create a button for new player 
                    ApplicationBarIconButton saveButton = new ApplicationBarIconButton();
                    //populate the button information 
                    saveButton.Text = "Add Player";
                    saveButton.IconUri = new Uri("/Images/add.png", UriKind.Relative);
                    saveButton.Click += new EventHandler(Save_Ascent);
                    //add the button to the application bar 
                    ApplicationBar.Buttons.Add(saveButton);
                    break;

                case 2:
                    
                    break;
               

            }
        }

       

        private void Save_Ascent(object sender, EventArgs e)
        {

        }

    }
}