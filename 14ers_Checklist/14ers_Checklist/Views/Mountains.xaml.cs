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
        public Mountains()
        {
            InitializeComponent();
            this.DataContext = ChecklistViewModel.getInstance(); 
        }

        private void MountainListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}