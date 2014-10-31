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
    public partial class CategoryCourses : PhoneApplicationPage
    {
        public CategoryCourses()
        {
            InitializeComponent();
        }

        private void remove_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyCategories.xaml", UriKind.Relative));
        }
    }
}