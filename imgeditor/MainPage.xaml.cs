using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using imgeditor.Resources;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Data;

using System.Windows.Controls.Primitives;
using Windows.Storage.Streams;

using Microsoft.Phone.Tasks;
using Windows.Storage.Streams;
using Microsoft.Xna.Framework.Media;

using System.IO;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using Nokia.Graphics.Imaging;
using Nokia.InteropServices.WindowsRuntime;
using System.IO.IsolatedStorage;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;
using vservWindowsPhone;
using GoogleAds;


namespace imgeditor
{
    public partial class MainPage : PhoneApplicationPage
    {
        PhotoChooserTask p = new PhotoChooserTask();
      
        
        public static BitmapImage capt;

        private InterstitialAd interstitialAd;

        public DispatcherTimer newTimer;

        bool askforReview = (bool)IsolatedStorageSettings.ApplicationSettings["askforreview"];

        //BitmapImage tex_effect = new BitmapImage(new Uri("/Images/light.jpg", UriKind.Relative));
       public static Image i;
        Image i2;

        

        public Timer time;

        String fl_name;

        String caption = "So..How is the App?? RATE With 5 STARS PLEASE..!!!!!!!";
        String content = "It will take less than a second. Rate the app";

        String caption2 = "So,How is the app??RATE it PLEASE..!!!!!!!";
        String content2 = "It will take less than a second. Just Rate the app";

        private string content3 = "All we want is your feedback. The developer has made alot of effort to develop this app for you. All we want is your feedback and rating. Pls rate the app!!! Just Tell us how it is. It will just take a second!!";
        private string caption3 = "Your feedback is important. PLease Rate The app";

        public static bool q;
            public bool e;

        public static int cn;

        StreamImageSource source;

        Stream s;

        int coun = 0;

        public static int nxt_cnt;

        public bool ad_flag = false;

        VservAdControl VAC = VservAdControl.Instance;
        

        private FilterEffect _cartoonEffect = null;
        private bool r;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            r = true;

            interstitialAd = new InterstitialAd("ca-app-pub-1177092011471737/6260163404");

                /*AdRequest adRequest = new AdRequest();
                adRequest.ForceTesting = true;
                interstitialAd.ReceivedAd += OnAdReceived;
                interstitialAd.FailedToReceiveAd += OnFailedToReceiveAd;
                interstitialAd.LoadAd(adRequest);
            */

          

            //VAC.DisplayAd("4fd4437a", LayoutRoot);

            //this.Loaded += AppView_Loaded; //Event for Showing Ad on Start
            VAC.SetRequestTimeOut(30);
            ad_flag = false;
            //VAC.SetTestMode(true);

            p.Completed += photoChooserTask_Completed;
            VAC.VservAdClosed += new EventHandler(VACCallback_OnVservAdClosing);
            //t1.IsEnabled = false;
            //t2.IsEnabled = false;
            //t3.IsEnabled = false;
            //t4.IsEnabled = false;
            q=false;
            cn = 0;

           
            

            //opacityslider.IsEnabled = false;
            

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        private void OnFailedToReceiveAd(object sender, AdErrorEventArgs errorCode)
        {
            r = true;
        }
        private void AppView_Loaded(object sender, RoutedEventArgs e)
        {
            //       VAC.DisplayAd("8063"/* Zone Id*/, LayoutRoot/* Layout over which the Ad will be displayed*/);
            if (adGrid != null)
                adGrid.Visibility = Visibility.Visible;
            VAC.SetRefreshRate(60); // This will refresh Ads at interval of 60 Seconds. Minimum allowed Refresh rate is 30 Sec.
            VAC.RenderAd("20846", adGrid);
            VAC.RenderAd("20846", adGrid_2);

            
            //VAC.RenderAd("20846", adGrid_3);
            //VAC.RenderAd("20846", adGrid_4);
        }


        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
                interstitialAd.ShowAd();
                r = true;
        }




        void OnTimerTick(Object sender, RoutedEventArgs args)
        {
            // text box property is set to current system date.
            // ToString() converts the datetime value into text
            
        }




        async void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                i = new Image();
                capt = new BitmapImage();
                capt.SetSource(e.ChosenPhoto);

                

                source = new StreamImageSource(e.ChosenPhoto);
                fl_name = e.OriginalFileName;

                i.Source = capt;
                i.Height = can.Height;
                i.Width = can.Width;

                i.Stretch = System.Windows.Media.Stretch.UniformToFill;
                //can.Height = i.Height;
                //can.Width = i.Width;
                can.Children.Add(i);

                q = true;

                t1.IsEnabled = true;
                t2.IsEnabled = true;
                //t3.IsEnabled = true;
                //t4.IsEnabled = true;


                IsolatedStorageFile Store = IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream Stream = new IsolatedStorageFileStream("photo.jpg", FileMode.Create, FileAccess.Write, Store);

                WriteableBitmap myImage = new WriteableBitmap((int)can.Width, (int)can.Height);
                myImage.SetSource(e.ChosenPhoto);

                myImage.SaveJpeg(Stream, (int)can.Width, (int)can.Height, 0, 100);

                Stream.Close();

                //opacityslider.IsEnabled = true;

                //_cartoonEffect = new FilterEffect(source);

                //var cartoonFilter = new CartoonFilter();
                //_cartoonEffect.Filters = new[] { cartoonFilter };


            }
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            /*AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = true;
            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.LoadAd(adRequest);*/

            if (r)
            {
                p.Show();
                // t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                //t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                //t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                //t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                //t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                //t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                //t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                //t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
            
        }

        private void texture(object sender, RoutedEventArgs e)
        {

            if (!MainPage.q)
            {
                MessageBox.Show("Load an Image first");
                return;
            }

            i2 = new Image();

            cn++;


            //t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            //t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            //t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            //t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            //t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            //t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            //t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            //t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

            
            can.Children.Clear();

           var tex_effect = new BitmapImage(new Uri("/Images/bfr.jpg", UriKind.Relative));

          // var tex_effect = new BitmapImage(new Uri("/Images/bl_1.jpg", UriKind.Relative)); 




            i2.Source = tex_effect;
            i2.Height = can.Height;
            i2.Width = can.Width;

            i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

            //Binding b = new Binding();
            //b.Source = opacityslider;
            //b.Path = new PropertyPath("Value");
            //i2.SetBinding(Image.OpacityProperty, b);
            i2.Opacity = 0.55;
          
            //can.Height = i.Height;
            //can.Width = i.Width;


            can.Children.Add(i);
            can.Children.Add(i2);

             if(askforReview && cn>2)
            {
                 newTimer = new DispatcherTimer();
                // timer interval specified as 1 second
                newTimer.Interval = TimeSpan.FromSeconds(5);
                // Sub-routine OnTimerTick will be called at every 1 second
                newTimer.Tick += OnTimerTick;
                // starting the timer
                newTimer.Start();

                //IsolatedStorageSettings.ApplicationSettings["done"] = true;
                //askforReview = false;
                var returnvalue = MessageBox.Show(content,caption, MessageBoxButton.OK);
                if (returnvalue == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["done"] = true;
                    askforReview = false;
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }

            }
            

        }

        void VACCallback_OnVservAdClosing(object sender, EventArgs e)
        {
            //MessageBox.Show("Ad Closed by user", "Interstitial Ad", MessageBoxButton.OK);
            BuildLocalizedApplicationBar();
            ad_flag = true;
            coun++;
            //count_box.Text = coun.ToString();
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton_load = new ApplicationBarIconButton(new Uri("/imag2/load.png", UriKind.Relative));
            appBarButton_load.Text = "load image";
            appBarButton_load.Click += AddButton_Click;

            ApplicationBar.Buttons.Add(appBarButton_load);

            ApplicationBarIconButton appBarButton_save = new ApplicationBarIconButton(new Uri("/imag2/save.png", UriKind.Relative));
            appBarButton_save.Text = "save image";
            appBarButton_save.Click += save_btn;
            ApplicationBar.Buttons.Add(appBarButton_save);

            ApplicationBarIconButton appBarButton_about = new ApplicationBarIconButton(new Uri("/imag2/about.png", UriKind.Relative));
            appBarButton_about.Text = "about";
            appBarButton_about.Click += next;
            ApplicationBar.Buttons.Add(appBarButton_about);

            ApplicationBarIconButton appBarButton_more = new ApplicationBarIconButton(new Uri("/imag2/add.png", UriKind.Relative));
            appBarButton_more.Text = " more apps";
            appBarButton_more.Click += mor;
            ApplicationBar.Buttons.Add(appBarButton_more);

            
        }

        void OnTimerTick(Object sender, EventArgs args)
        {
            // text box property is set to current system date.
            // ToString() converts the datetime value into text
            //newTimer.Stop();
        }


        private  void texture2(object sender, RoutedEventArgs e)
        {
            if(!MainPage.q)
            {
                MessageBox.Show("Load an Image first");
                return;
            }


            i2 = new Image();
            cn++;


           /* if (cn % 2 == 0)
            {
                AdRequest adRequest = new AdRequest();
                interstitialAd.ReceivedAd += OnAdReceived;
                interstitialAd.LoadAd(adRequest);


            }*/


            t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           // t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           //// t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

           // t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           // t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           // t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

           // t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           // t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           // t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
           // t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

            

            can.Children.Clear();

            var tex_effect = new BitmapImage(new Uri("/Images/gol.jpg", UriKind.Relative));

            //var tex_effect = new BitmapImage(new Uri("/Images/gr.jpg", UriKind.Relative));

            i2.Source = tex_effect;
            i2.Height = can.Height;
            i2.Width = can.Width;

            i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

            //Binding b = new Binding();
            //b.Source = opacityslider;
            //b.Path = new PropertyPath("Value");
            //i2.SetBinding(Image.OpacityProperty, b);
            i2.Opacity = 0.75;
            //can.Height = i.Height;
            //can.Width = i.Width;
             can.Children.Add(i);
            can.Children.Add(i2);

            if (askforReview && cn > 2)
            {

                newTimer = new DispatcherTimer();
                // timer interval specified as 1 second
                newTimer.Interval = TimeSpan.FromSeconds(5);
                // Sub-routine OnTimerTick will be called at every 1 second
                newTimer.Tick += OnTimerTick;
                // starting the timer
                newTimer.Start();

                //IsolatedStorageSettings.ApplicationSettings["done"] = true;
                //askforReview = false;
                var returnvalue = MessageBox.Show(content,caption, MessageBoxButton.OK);
                if (returnvalue == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["done"] = true;
                    askforReview = false;
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }

            }

        }


      /*  private void texture3(object sender, RoutedEventArgs e)
        {
            if (!MainPage.q)
            {
                MessageBox.Show("Load an Image first");
                return;
            }

            i2 = new Image();


            t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

            cn++;

            if (cn % 2 == 0)
            {
                AdRequest adRequest = new AdRequest();
                interstitialAd.ReceivedAd += OnAdReceived;
                interstitialAd.LoadAd(adRequest);


            }

            can.Children.Clear();

            var tex_effect = new BitmapImage(new Uri("/Images/st_bl.jpg", UriKind.Relative));

            t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

            i2.Source = tex_effect;
            i2.Height = can.Height;
            i2.Width = can.Width;

            i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

            //Binding b = new Binding();
            //b.Source = opacityslider;
            //b.Path = new PropertyPath("Value");
            //i2.SetBinding(Image.OpacityProperty, b);
            i2.Opacity = 0.55;
            //can.Height = i.Height;
            //can.Width = i.Width;
            can.Children.Add(i);
            can.Children.Add(i2);

            if (askforReview && cn > 2)
            {
                newTimer = new DispatcherTimer();
                // timer interval specified as 1 second
                newTimer.Interval = TimeSpan.FromSeconds(5);
                // Sub-routine OnTimerTick will be called at every 1 second
                newTimer.Tick += OnTimerTick;
                // starting the timer
                newTimer.Start();

                //IsolatedStorageSettings.ApplicationSettings["done"] = true;
                //askforReview = false;
                var returnvalue = MessageBox.Show(content,caption, MessageBoxButton.OK);
                if (returnvalue == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["done"] = true;
                    askforReview = false;
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }

            }


        }*/



        //private void texture4(object sender, RoutedEventArgs e)
        //{
        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if (cn % 2 == 0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/vass.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content,caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void texture5(object sender, RoutedEventArgs e)
        //{
        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if (cn % 2 == 0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //     t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)); 
        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            

        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/yl_sh.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void texture6(object sender, RoutedEventArgs e)
        //{
        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if (cn % 2 == 0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));



        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/str.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void texture7(object sender, RoutedEventArgs e)
        //{
        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if(cn%2==0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));



        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/bl_sh.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void texture8(object sender, RoutedEventArgs e)
        //{

        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if (cn % 2 == 0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));



        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/disco.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void texture9(object sender, RoutedEventArgs e)
        //{

        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if (cn % 2 == 0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));



        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/gard.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void texture10(object sender, RoutedEventArgs e)
        //{
        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if (cn % 2 == 0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));



        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/vert.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void texture11(object sender, RoutedEventArgs e)
        //{

        //    if (!MainPage.q)
        //    {
        //        MessageBox.Show("Load an Image first");
        //        return;
        //    }

        //    i2 = new Image();

        //    cn++;

        //    if (cn % 2 == 0)
        //    {
        //        AdRequest adRequest = new AdRequest();
        //        interstitialAd.ReceivedAd += OnAdReceived;
        //        interstitialAd.LoadAd(adRequest);


        //    }

        //    t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //   // t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        //    t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        //    t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));



        //    t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

        //    can.Children.Clear();

        //    var tex_effect = new BitmapImage(new Uri("/Images/vl_sh.jpg", UriKind.Relative));

        //    i2.Source = tex_effect;
        //    i2.Height = can.Height;
        //    i2.Width = can.Width;

        //    i2.Stretch = System.Windows.Media.Stretch.UniformToFill;

        //    //Binding b = new Binding();
        //    //b.Source = opacityslider;
        //    //b.Path = new PropertyPath("Value");
        //    //i2.SetBinding(Image.OpacityProperty, b);
        //    i2.Opacity = 0.55;
        //    //can.Height = i.Height;
        //    //can.Width = i.Width;
        //    can.Children.Add(i);
        //    can.Children.Add(i2);

        //    if (askforReview && cn > 2)
        //    {
        //        newTimer = new DispatcherTimer();
        //        // timer interval specified as 1 second
        //        newTimer.Interval = TimeSpan.FromSeconds(5);
        //        // Sub-routine OnTimerTick will be called at every 1 second
        //        newTimer.Tick += OnTimerTick;
        //        // starting the timer
        //        newTimer.Start();

        //        //IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //        //askforReview = false;
        //        var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
        //        if (returnvalue == MessageBoxResult.OK)
        //        {
        //            IsolatedStorageSettings.ApplicationSettings["done"] = true;
        //            askforReview = false;
        //            var marketplaceReviewTask = new MarketplaceReviewTask();
        //            marketplaceReviewTask.Show();
        //        }

        //    }


        //}

        //private void sl_ch(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    //double newvalue = (double)e.NewValue;
        //    //opacityslider.Value = newvalue;
        //    i2.Opacity = opacityslider.Value;
        //}

        private void save_btn(object sender, EventArgs e)
        {
            //cn++;
            if (!MainPage.q)
            {
                MessageBox.Show("Load an Image first");
            }
            else if (askforReview && cn>=1)
            {
                //cn++;
                var bit = new WriteableBitmap((int)can.Width, (int)can.Height);
                bit.Render(can, null);
                bit.Invalidate();


                var tempName = Guid.NewGuid().ToString();
                var store = IsolatedStorageFile.GetUserStoreForApplication();
                var fileStream = store.CreateFile(tempName);

                Extensions.SaveJpeg(bit, fileStream, bit.PixelWidth, bit.PixelHeight, 0, 100);
                fileStream.Close();




                var fileStream_2 = store.OpenFile(tempName, FileMode.Open, FileAccess.Read);
                var library = new MediaLibrary();
                var pic = library.SavePicture(fl_name + " edited", fileStream_2);

                MessageBox.Show("Image saved!");

                var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
                if (returnvalue == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["done"] = true;
                    askforReview = false;
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }

            }

            else
            {
                var bit = new WriteableBitmap((int)can.Width, (int)can.Height);
                bit.Render(can, null);
                bit.Invalidate();


                var tempName = Guid.NewGuid().ToString();
                var store = IsolatedStorageFile.GetUserStoreForApplication();
                var fileStream = store.CreateFile(tempName);

                Extensions.SaveJpeg(bit, fileStream, bit.PixelWidth, bit.PixelHeight, 0, 100);
                fileStream.Close();




                var fileStream_2 = store.OpenFile(tempName, FileMode.Open, FileAccess.Read);
                var library = new MediaLibrary();
                var pic = library.SavePicture(fl_name + " edited", fileStream_2);

                MessageBox.Show("Image saved!");
            }
            //SaveToMediaLibrary(bit, fl_name+"edited", 100);

            //using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    String strImageName = "demo.jpg";  // File name. 


            //    if (iso.FileExists(strImageName))
            //    {
            //        iso.DeleteFile(strImageName);
            //    }

            //    using (IsolatedStorageFileStream isostream = iso.CreateFile(strImageName))
            //    {
            //        // Encode WriteableBitmap object to a JPEG stream. 
            //        Extensions.SaveJpeg(bit, isostream, bit.PixelWidth, bit.PixelHeight, 0, 85);
            //        isostream.Close();
            //    }



            //    using (IsolatedStorageFileStream fileStream = iso.OpenFile(strImageName, FileMode.Open, FileAccess.Read))
            //    {
            //        MediaLibrary mediaLibrary = new MediaLibrary();
            //        Picture pic = mediaLibrary.SavePicture(strImageName, fileStream);
            //        fileStream.Close();
            //    }




                // var su = new StreamImageSource(fileStream);



                //_cartoonEffect = new FilterEffect(source);

                //var cartoonFilter = new CartoonFilter();
                //_cartoonEffect.Filters = new[] { cartoonFilter };

                //var jpegRenderer = new JpegRenderer(_cartoonEffect);



                //IBuffer jpegOutput = await jpegRenderer.RenderAsync();

                // Save the image as a jpeg to the saved pictures album.
                //MediaLibrary library = new MediaLibrary();
                //string fileName = string.Format("CartoonImage_{0:G}", DateTime.Now);
                //var picture =  library.SavePicture(fileName, fileStream);

               

            //}
        }


        public void SaveToMediaLibrary(WriteableBitmap bitmap, string name, int quality)
        {
            using (var stream = new MemoryStream())
            {
                // Save the picture to the Windows Phone media library.
                bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, quality);
                stream.Seek(0, SeekOrigin.Begin);
                //new MediaLibrary().SavePicture(name, stream);

                MediaLibrary library = new MediaLibrary();
                //string fileName = string.Format("CartoonImage_{0:G}", DateTime.Now);
                var picture =  library.SavePicture(name, stream);
            }
        }


        //private void CreateSaveBitmap(Canvas canvas, string filename)
        //{
        //    RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
        //     (int)canvas.Width, (int)canvas.Height,
        //     96d, 96d, PixelFormats.Pbgra32);
        //    // needed otherwise the image output is black
        //    canvas.Measure(new Size((int)canvas.Width, (int)canvas.Height));
        //    canvas.Arrange(new Rect(new Size((int)canvas.Width, (int)canvas.Height)));

        //    renderBitmap.Render(canvas);

        //    //JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //    PngBitmapEncoder encoder = new PngBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

        //    using (FileStream file = File.Create(filename))
        //    {
        //        encoder.Save(file);
        //    }
        //}


        //private void sl_ch()
        //{
            
        //}






        //public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        //{
        //    Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
        //    Graphics graphics = Graphics.FromImage(bmp);
        //    ColorMatrix colormatrix = new ColorMatrix();
        //    colormatrix.Matrix33 = opacityvalue;
        //    ImageAttributes imgAttribute = new ImageAttributes();
        //    imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        //    graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
        //    graphics.Dispose();   // Releasing all resource used by graphics
        //    return bmp;
        //}


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}


        private void favs(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        private void mor(object sender, EventArgs e)
        {
            if (r)
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.URL = "http://www.windowsphone.com/en-IN/store/publishers?publisherId=Kapil%2BBakshi&appId=af539d57-008f-44ad-bb1b-b7738f75d5e1";
                webBrowserTask.Show();
            }
            //ShareStatusTask shareStatusTask = new ShareStatusTask();

            //shareStatusTask.Status = "JNJNNKKJNKKJNJN";

            //shareStatusTask.Show();
        }

        private void next(object sender, EventArgs e)
        {
            //ShareLinkTask shareLinkTask = new ShareLinkTask();
            //shareLinkTask.Title = "Try this awesome REFLEXES + MEMORY GAME";
            //shareLinkTask.LinkUri = new Uri("http://www.windowsphone.com/en-in/search?q=kapil+bakshi", UriKind.Absolute);
            //shareLinkTask.Message = "My Level 2 score is " + score.ToString() + " This game is simply outstanding.Lets you test and improve your memory,reflexes and concentration.The challenging and extremely interesting levels just don't let you blink your eye and let you enjoy yourself to the fullest. ";
            //shareLinkTask.Show();

            //NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));

            //nxt_cnt++;

            if (r)
            {
                NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
            }
        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            
            if (askforReview && cn >= 1)
            {
                var s = MessageBox.Show(content3, caption3, MessageBoxButton.OK);
                //e.Cancel = MessageBoxResult.Cancel == MessageBox.Show(message, caption, MessageBoxButton.OKCancel);

                if (s == MessageBoxResult.OK)
                {
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }

            }

           /* AdRequest adRequest = new AdRequest();
            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.LoadAd(adRequest);*/

            
               // Application.Current.Terminate();


            NavigationService.Navigate(new Uri("/ExitPage.xaml", UriKind.Relative));
            
            base.OnBackKeyPress(e);

        }

        //private void g(object sender, RoutedEventArgs e)
        //{
        //    coun++;
        //    count_box.Text = coun.ToString();
        //}

       /* protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            Application.Current.Terminate();
                
        }*/

    }

}