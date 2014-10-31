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

namespace Learnterest
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private async void rate(object sender, System.Windows.Input.GestureEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(
    new Uri("ms-windows-store:reviewapp?appid=2a4a3ef5-6e1f-4830-bf26-8705670ab3da"));
        }

        private void share(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();
            shareLinkTask.LinkUri = new Uri("http://www.learnterest.com", UriKind.Absolute);
           // shareLinkTask.Message = "Sample Facebook message!";
            shareLinkTask.Title = "The online learning marketplace!";
            shareLinkTask.Show();
        }

        private void feedback(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();
            task.To = "lmssupport@deemsysinc.com";
            task.Subject = "Learnterest feedback/suggestions";
            task.Body = "Sent from \n\r Windows phone";
            task.Show();
        }

        private void website_open(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();

            webBrowserTask.Uri = new Uri("http://www.learnterest.com", UriKind.Absolute);

            webBrowserTask.Show();
        }
    }
}