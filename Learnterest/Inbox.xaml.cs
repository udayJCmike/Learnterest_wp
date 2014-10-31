using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Learnterest
{
    public partial class Inbox : PhoneApplicationPage
    {
        public Inbox()
        {
            InitializeComponent();
        }

        private void inbox_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Inbox.xaml", UriKind.Relative));
        }

        private void billing_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Billing.xaml", UriKind.Relative));
        }

        private void settings_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

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

        private void logout_click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure want to logout?", "logout", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/Authenticate.xaml", UriKind.Relative));
            }
        }

        private void test_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/InboxDetail.xaml", UriKind.Relative));
        }

        private void sync_click(object sender, EventArgs e)
        {
            MessageBox.Show("Inbox Synced!");
           // NavigationService.Navigate(new Uri("/InboxDetail.xaml", UriKind.Relative));
        }

    }
}