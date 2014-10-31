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
    public partial class InboxDetail : PhoneApplicationPage
    {
        public InboxDetail()
        {
            InitializeComponent();
        }


        private void important_click(object sender, EventArgs e)
        {
            MessageBox.Show("Marked as important");
            //NavigationService.Navigate(new Uri("/InboxDetail.xaml", UriKind.Relative));
        }
    }
}