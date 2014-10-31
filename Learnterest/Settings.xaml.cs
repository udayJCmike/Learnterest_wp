using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;

namespace Learnterest
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void profile(Object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Profile.xaml", UriKind.Relative));
        }

        private void contact(Object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Contact.xaml", UriKind.Relative));
        }

        private void policy(Object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Policies.xaml", UriKind.Relative));
        }

        private void about(Object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void help(Object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }


        //private void policies_event(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/Policies.xaml", UriKind.Relative));
        //}

        //private void contact_event(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/contact.xaml", UriKind.Relative));
        //}

        //private void about_event(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        //}

        //private void help_event(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        //}

        private void home_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }

        private void mycourses_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyCourses.xaml", UriKind.Relative));
        }

        private void mycategories_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyCategories.xaml", UriKind.Relative));
        }

        private void myfavourites_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyFavourites.xaml", UriKind.Relative));
        }

        private void myauthors_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyAuthors.xaml", UriKind.Relative));
        }

        private void inbox_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/inbox.xaml", UriKind.Relative));
        }

        private void billing_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/billing.xaml", UriKind.Relative));
        }

        private void settings_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/settings.xaml", UriKind.Relative));
        }

        private void logout_click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure want to logout?", "logout", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/Authenticate.xaml", UriKind.Relative));
            }
        }
    }
}