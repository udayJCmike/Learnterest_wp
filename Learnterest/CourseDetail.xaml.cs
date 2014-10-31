using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using System.Windows.Threading;
using System.Threading;

namespace Learnterest
{
    public partial class CourseDetail : PhoneApplicationPage
    {
       // private double totalSeconds = 1;
        private double duration;
        DispatcherTimer timer = new DispatcherTimer();
        public CourseDetail()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_tick);
            promoslider.Value = 0;

        }

       

        private void rewind_click(object sender, EventArgs e)
        {
            int currentposition = (int)promoslider.Value;
            promoslider.Value = currentposition - 10000;
            Debug.WriteLine(currentposition);
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, currentposition-10000);
            Debug.WriteLine(ts);
            promomedia.Position = ts;
           // double testvideo = promomedia.Position.TotalMilliseconds;
           // double testslide = promoslider.Value;
            
        }

        private void play_click(object sender, EventArgs e)
        {
            promomedia.Play();
            timer.Start();
            promomedia.MediaFailed += new EventHandler<ExceptionRoutedEventArgs>(MediaElement_MediaFailed);
         
        }

        private void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            var errorException = e.ErrorException;
            MessageBox.Show("can't Play"+errorException);
            throw new NotImplementedException();
        }

        private void pause_click(object sender, EventArgs e)
        {
            promomedia.Pause();
            timer.Stop();
        }

        private void forward_click(object sender, EventArgs e)
        {
            int currentposition = (int)promoslider.Value;
            Debug.WriteLine(currentposition);
            promoslider.Value = currentposition + 10000;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, currentposition+10000);
            Debug.WriteLine(ts);
            promomedia.Position = ts;

            //double current = promomedia.Position.TotalMilliseconds;
           // Debug.WriteLine("video play time" + current);
           // Debug.WriteLine("video play time" + current);
        }

        private void media_opened(object sender, RoutedEventArgs e)
        {
            duration = promomedia.NaturalDuration.TimeSpan.TotalMilliseconds;
            Debug.WriteLine("duration" + duration);
            promoslider.Maximum = promomedia.NaturalDuration.TimeSpan.TotalMilliseconds;
            Debug.WriteLine("slider max value" + promoslider.Maximum.ToString());
        }

          void timer_tick(object sender, EventArgs e)
        {
            if (promomedia.CurrentState == System.Windows.Media.MediaElementState.Playing)
            {
                double current = promomedia.Position.TotalMilliseconds;
                //Debug.WriteLine("video play time" + current);
                //double progress = (current * 100) / duration.TotalMilliseconds;
                promoslider.Value = current;
               // Debug.WriteLine("slider value" + progress);
            }
        }


        private void media_ended(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0,9970000);
            Debug.WriteLine(ts);
            promomedia.Position = ts;
            int reset = 997;
            promoslider.Value = reset;

            promomedia.Play();
            Thread.Sleep(1000);
            promomedia.Pause();
            timer.Stop();
        }

        private void seek_slider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int currentposition = (int)promoslider.Value;
            Debug.WriteLine(currentposition);
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, currentposition);
            Debug.WriteLine(ts);
            promomedia.Position = ts;
        }

        private void buffered(object sender, RoutedEventArgs e)
        {

        }

        private void text(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CourseText.xaml", UriKind.Relative));
        }

        private void audio(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CourseAudio.xaml", UriKind.Relative));

        }

        private void video(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CourseVideo.xaml", UriKind.Relative));

        }
    }
}