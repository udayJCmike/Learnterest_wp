using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace Learnterest
{
    public partial class Profile : PhoneApplicationPage
    {
        //Global variable declaration
        string gendervalue = "male";
        string interestvalue = "courses";
        string oldpassfetch = "qwerty";
        public Profile()
        {
            //constructor
            InitializeComponent();
            
        }

      //private methods and event handlers
        private void update_profile(object sender, RoutedEventArgs e)
        {
            //calculation for gender and interst
            int genderindex = genderlist.SelectedIndex;         
            int interestindex = genderlist.SelectedIndex;
            if (genderindex == 0)
            {
                 gendervalue = "male";
            }
            else gendervalue = "female";

            if (interestindex == 0)
            {
                interestvalue = "male";
            }
            else interestvalue = "female";

            //validation on other fields not null and empty spaces
            if ((string.IsNullOrWhiteSpace(this.fname.Text)) || (string.IsNullOrWhiteSpace(this.lname.Text)) || (string.IsNullOrWhiteSpace(this.email.Text)))
            {
                MessageBox.Show("Required fields should not be empty!");
            }
            else
                MessageBox.Show("profile update Successfull!!");
        }

        private void validate_fname(object sender, RoutedEventArgs e)
        {
            Match match = new Regex(@"^[a-zA-Z]+[a-zA-Z]{1,2}$").Match(fname.Text);

            if (match.Success)
            {
                lname.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid firstname!");
                fname.Text = "";
            }
        }

        private void validate_lname(object sender, RoutedEventArgs e)
        {
            Match match = new Regex(@"^[a-zA-Z]+[a-zA-Z]{1,2}$").Match(lname.Text);

            if (match.Success)
            {
                email.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid lastname!");
                lname.Text = "";
            }
        }

        private void validate_email(object sender, RoutedEventArgs e)
        {
            Match match = new Regex(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$").Match(email.Text);

            if (match.Success)
            {
                MessageBox.Show("query for availability!");
                genderlist.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid email!");
                email.Text = "";

            }
        }

        private void validate_oldpassword(object sender, RoutedEventArgs e)
        {
            if (oldpass.Password == oldpassfetch)
            {
                newpass.Focus();
            }
            else
            {
                MessageBox.Show("Old password incorrect!");
                oldpass.Password = "";
            }
        }

        private void change_password(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(this.oldpass.Password)) || (string.IsNullOrWhiteSpace(this.newpass.Password)) || (string.IsNullOrWhiteSpace(this.cnewpass.Password)))
            {
                MessageBox.Show("Required fields should not be empty!");
            }
            else
                MessageBox.Show("change password Successfull!!");
        }

        private void validate_newpass(object sender, RoutedEventArgs e)
        {
            Match match = new Regex(@"^(?=(.*\d){1})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{6,25}$").Match(newpass.Password);

            if (match.Success)
            {
                cnewpass.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid password!");
                newpass.Password = "";
            }
        }

        private void validate_cnewpass(object sender, RoutedEventArgs e)
        {

            if (cnewpass.Password == newpass.Password)
            {
                changepasswordbutton.Focus();
            }
            else
            {
                MessageBox.Show("Password didn't match!");
                newpass.Password = "";
                cnewpass.Password = "";
            }
        }

    }
}