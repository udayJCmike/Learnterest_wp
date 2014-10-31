using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;

namespace Learnterest
{
    
    public partial class Authenticate : PhoneApplicationPage
    {
       
        public Authenticate()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBar.ForegroundColor = Color.FromArgb(255,48,135,207);
            ApplicationBar.BackgroundColor = Colors.White;
            ApplicationBarIconButton button1 = new ApplicationBarIconButton();
            button1.IconUri = new Uri("/Images/next.png", UriKind.Relative);
            button1.Text = "skip";
            button1.Click += skip_click;
            ApplicationBar.Buttons.Add(button1);

            //Code to add menu item
            //ApplicationBarMenuItem menuItem1 = new ApplicationBarMenuItem();
            //menuItem1.Text = "menu item 1";
            //ApplicationBar.MenuItems.Add(menuItem1);
            //loginpass2.Visibility = Visibility.Collapsed;   
        }

        private void skip_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri ("/ExploreCourses.xaml", UriKind.Relative));
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //base.OnBackKeyPress(e)
            e.Cancel = true;
        }

        private void login_event(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(this.loginname.Text)) || (string.IsNullOrWhiteSpace(this.loginpass.Password)))
            {
                MessageBox.Show("Required fields should not be empty!");
            }
            else
            {
                //NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
                string url = "http://192.168.1.217:8888/windowsphone/Services/Login.php?service=login";
                Uri uri = new Uri(url, UriKind.Absolute);
                StringBuilder postData = new StringBuilder();
                postData.AppendFormat("{0}={1}", "username",HttpUtility.UrlEncode(this.loginname.Text));
                postData.AppendFormat("&{0}={1}", "password", HttpUtility.UrlEncode(this.loginpass.Password.ToString()));
                WebClient client = default(WebClient);
                client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                client.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();
                client.UploadStringCompleted += client_UploadStringCompleted;
                client.UploadStringAsync(uri, "POST", postData.ToString());
                ApplicationBar.IsVisible = false;
                progress1.Visibility = Visibility.Visible;
                progress1.IsIndeterminate = true;
                pivot1.IsHitTestVisible = false;
            }
         }


        private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Cancelled == false & e.Error == null)
            {
                ApplicationBar.IsVisible = true;
                progress1.Visibility = Visibility.Collapsed;
                progress1.IsIndeterminate = false;
                pivot1.IsHitTestVisible = true;

             //   string[] result = e.Result.ToString().Split('|');
               // string strStatus = result[0].ToString();
              //  string values = result[1].ToString();
               // string strError = result[2].ToString();

               // if (strStatus == "0")
               // {
               //     MessageBox.Show(strError);
              //  }
                
           //     {
                    Member myMember = ReadToObject(e.Result.ToString());
                    string name = myMember.firstname.ToString();
                    MessageBox.Show(name);
              //  }
            }
        }

        public static Member ReadToObject(string json)
        {
            Member deserializedMember = new Member();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedMember.GetType());
            deserializedMember = ser.ReadObject(ms) as Member;
            ms.Close();
            return deserializedMember;
        }
        private void signup_event(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(this.fname.Text)) || (string.IsNullOrWhiteSpace(this.lname.Text)) || (string.IsNullOrWhiteSpace(this.uname.Text)) || (string.IsNullOrWhiteSpace(this.email.Text)) || (string.IsNullOrWhiteSpace(this.pass.Password)) || (string.IsNullOrWhiteSpace(this.cpass.Password)))
            {              
                    MessageBox.Show("Required fields should not be empty!");            
            }
            else if (agree.IsChecked == false)
            {
                MessageBox.Show("Please accept our terms of service!");
            }
            else
                MessageBox.Show("Signup Successfull!!");
           // MessageBox.Show("Signup Successfull!!");
           // NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
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
                uname.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid lastname!");
                lname.Text = "";

            }
        }

        private void validate_uname(object sender, RoutedEventArgs e)
        {
            Match match = new Regex(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$").Match(uname.Text);

            if (match.Success)
            {
                MessageBox.Show("query for availability!");
                email.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid username!");
                uname.Text = "";

            }
        }

        private void validate_email(object sender, RoutedEventArgs e)
        {
            Match match = new Regex(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"+ "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$").Match(email.Text);

            if (match.Success)
            {
                MessageBox.Show("query for availability!");
                pass.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid email!");
                email.Text = "";

            }
        }

        private void validate_pass(object sender, RoutedEventArgs e)
        {
            Match match = new Regex(@"^(?=(.*\d){1})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{6,25}$").Match(pass.Password);

            if (match.Success)
            {
                cpass.Focus();
            }
            else
            {
                MessageBox.Show("Please enter valid password!");
                pass.Password = "";

            }
        }

        private void validate_cpass(object sender, RoutedEventArgs e)
        {
           
            if (cpass.Password==pass.Password)
            {
                agree.Focus();
            }
            else
            {
                MessageBox.Show("Password didn't match!");
                pass.Password = "";
                cpass.Password = "";

            }
        }

        private void show_password(object sender, RoutedEventArgs e)
        {
            loginpass.Visibility = Visibility.Collapsed;
            loginpass2.Text = loginpass.Password;
            loginpass2.Visibility = Visibility.Visible;
        }

        private void uncheck(object sender, RoutedEventArgs e)
        {
            loginpass2.Visibility = Visibility.Collapsed;
            loginpass.Password = loginpass2.Text;
            loginpass.Visibility = Visibility.Visible;
        }

        private void updatepassword(object sender, RoutedEventArgs e)
        {
            loginpass2.Text = loginpass.Password;
        }

        private void updatepassword1(object sender, RoutedEventArgs e)
        {
            loginpass.Password = loginpass2.Text;
        }
    }

    [DataContract]
    public class Member
    {
        [DataMember]
        public string studentid { get; set; }
        [DataMember]
        public string firstname { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string interest { get; set; }
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string avatarurl { get; set; }
        [DataMember]
        public string courseimageurl { get; set; }
        [DataMember]
        public string avatarimage { get; set; }
        [DataMember]
        public string logins { get; set; }
        public Member()
        {
        }
        public Member(string strstudentid, string strfirstname, string strlastname, string strusername, string stremail, string strpassword, string strinterest, string strgender, string stravatarurl, string strcourseimageurl, string stravatarimage, string strlogins)
        {
            this.studentid = strstudentid;
            this.firstname = strfirstname;
            this.lastname = strlastname;
            this.username = strusername;
            this.email = stremail;
            this.password = strpassword;
            this.interest = strinterest;
            this.gender = strgender;
            this.avatarurl = stravatarurl;
            this.courseimageurl = strcourseimageurl;
            this.avatarimage = stravatarimage;
            this.logins = strlogins;
        }
    }
}

