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
    public partial class Contact : PhoneApplicationPage
    {
        PhoneCallTask phoneTask = null;
        public Contact()
        {
            InitializeComponent();
            phoneTask = new PhoneCallTask();     
           
        }

        private void call_us(object sender, System.Windows.Input.GestureEventArgs e)
        {
            phoneTask.DisplayName = "learnterest corporate";
            phoneTask.PhoneNumber = "6143229928"; // put your desired phone number here
            phoneTask.Show();
        }

        private void call_ind(object sender, System.Windows.Input.GestureEventArgs e)
        {

            phoneTask.DisplayName = "learnterest support";
            phoneTask.PhoneNumber = "9841122989"; // put your desired phone number here
            phoneTask.Show();
        }

        private void support_mail(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();
            task.To = "lmssupport@deemsysinc.com";
            task.Subject = "Requesting for learnterest support";
            task.Body="Sent from \n\r Windows phone";
            task.Show();
        }
    }
}