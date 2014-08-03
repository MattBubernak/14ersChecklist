using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks; 

namespace _14ers_Checklist.Views
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void send_email(object sender, RoutedEventArgs e)
        {
            var task = new EmailComposeTask { To = "BirdBucketProductions@gmail.com" };
            task.Show();
        }

    }
}