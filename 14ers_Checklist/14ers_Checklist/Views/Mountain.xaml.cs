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
    public partial class Mountain : PhoneApplicationPage
    {
        public Mountain()
        {
            InitializeComponent();
            DataContext = null; 
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
    }
}