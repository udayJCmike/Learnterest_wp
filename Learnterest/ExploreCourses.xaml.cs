﻿using System;
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
    public partial class ExploreCourses : PhoneApplicationPage
    {
        public ExploreCourses()
        {
            InitializeComponent();
        }

        private void search_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        private void login_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Authenticate.xaml", UriKind.Relative));
        }
       
    }


}