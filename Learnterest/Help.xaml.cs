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
    public partial class Help : PhoneApplicationPage
    {
        public Help()
        {
            InitializeComponent();

            //Help page contents
            inboxhelp.Text = "The inbox page contains list of messages sent from learnterest from admin to students. These message are sent while enrollment of course by as student. The message are sent for both paid courses as well as free courses. The paid course message includes transaction details along with the message.";
            billinghelp.Text = "The billing page contains list of trasaction details for paid courses.You can view complete transaction details like transaction date,discount amount,paid amount,transaction status,transacion id etc.";
            homehelp.Text = "The home page contains list of courses with all,free,paid type.You can search courses by course name.Also you can find courses by category type.";
            courseshelp.Text = "The courses page contains list of enrolled courses with short description.You can read complete course details by selecting a particular course from list.";
            categoryhelp.Text = "The category page contains list of favorite categories which are enrolled by as student.You can add and remove categories from favorites.You can see list of courses for each category by selecting category name from list.";
            favhelp.Text = "The favorite page contains list of favorite courses which are enrolled by as student.You can add and remove courses from favorites .You can view complete course details by selecting a particular course from list.";
            authorhelp.Text = "The author page contains list of author names which are enrolled by as student.You can add and remove author from your favorite list.You can see list of author's courses by selecting author name from list.";
            settinghelp.Text = "The settings page contains password change,profile update features.You can get more details about application version number,build number and contact details.You can find more information about deemsys.";

          
        }
    }
}