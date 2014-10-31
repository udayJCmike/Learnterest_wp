using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;

namespace Learnterest
{
    public partial class Promotional : PhoneApplicationPage
    {
        public Promotional()
        {
            InitializeComponent();
            Thread.Sleep(2000);
           
        }


        private void explorecourses_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ExploreCourses.xaml", UriKind.Relative));
        }

        private void login_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Authenticate.xaml", UriKind.Relative));
        }

        private void contact_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Contact.xaml", UriKind.Relative));
        }

        private void policy_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Policies.xaml", UriKind.Relative));
        }

        private void about_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        //private void rate_click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Rate success");
        //}

        private void help_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }
    }
}