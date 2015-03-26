using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using System.IO;
using Nokia.Graphics.Imaging;
using GoogleAds;

namespace imgeditor
{
    public partial class Page3 : PhoneApplicationPage
    {
         public Image i2, i;

        PhotoChooserTask p = new PhotoChooserTask();

        public bool q;

        private InterstitialAd interstitialAd;

        StreamImageSource source;

        String caption = "So..How is the App?? RATE With 5 STARS PLEASE..!!!!!!!";
        String content = "It will take less than a second. Rate the app";

        bool askforReview = (bool)IsolatedStorageSettings.ApplicationSettings["askforreview"];
        private BitmapImage capt;
        public Page3()
        {
            InitializeComponent();

            interstitialAd = new InterstitialAd("ca-app-pub-1177092011471737/6260163404");

            MainPage.nxt_cnt =0;

            //AdRequest adRequest = new AdRequest();
            //adRequest.ForceTesting = true;
            //interstitialAd.ReceivedAd += OnAdReceived;
            //interstitialAd.LoadAd(adRequest);

            if (MainPage.nxt_cnt == 3)
            {

                MainPage.nxt_cnt = 0;

                //AdRequest adRequest = new AdRequest();
                //adRequest.ForceTesting = true;
                //interstitialAd.ReceivedAd += OnAdReceived;
                //interstitialAd.LoadAd(adRequest);
            }

            i = new Image();

            i.Source = MainPage.capt;
            i.Height = can.Height;
            i.Width = can.Width;

            i.Stretch = System.Windows.Media.Stretch.UniformToFill;

            if (MainPage.q)
            {
                can.Children.Add(i);
            }

            p.Completed += photoChooserTask_Completed;
        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
            interstitialAd.ShowAd();
        }

        private void texture3(object sender, RoutedEventArgs e)
        {
            if (!MainPage.q)
            {
                MessageBox.Show("Load an Image first");
                return;
            }

            i2 = new Image();


            /* t1.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
             t2.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
             t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

             t5.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
             t6.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
             t7.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

             t8.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
             t9.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
             t10.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
             t11.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

             t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));*/

            MainPage.cn++;

            /* if (MainPage.cn % 2 == 0)
             {
                 AdRequest adRequest = new AdRequest();
                 interstitialAd.ReceivedAd += OnAdReceived;
                 interstitialAd.LoadAd(adRequest);


             }*/

            can.Children.Clear();

            var tex_effect = new BitmapImage(new Uri("/Images/yl_sh.jpg", UriKind.Relative));

            t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));
            t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 255));

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

            if (askforReview && MainPage.cn > 2)
            {
                /* newTimer = new DispatcherTimer();
                 // timer interval specified as 1 second
                 newTimer.Interval = TimeSpan.FromSeconds(5);
                 // Sub-routine OnTimerTick will be called at every 1 second
                 newTimer.Tick += OnTimerTick;
                 // starting the timer
                 newTimer.Start();*/

                //IsolatedStorageSettings.ApplicationSettings["done"] = true;
                //askforReview = false;
                var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
                if (returnvalue == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["done"] = true;
                    askforReview = false;
                    IsolatedStorageSettings.ApplicationSettings["askforreview"] = askforReview;
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }

            }


        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            p.Show();
            t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));


        }


        private void prev(object sender, EventArgs e)
        {
            /* if (this.NavigationService.CanGoBack)

              {

                  this.NavigationService.GoBack();

             }*/

            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));


        }


        private void texture4(object sender, RoutedEventArgs e)
        {
            if (!MainPage.q)
            {
                MessageBox.Show("Load an Image first");
                return;
            }

            i2 = new Image();

            MainPage.cn++;

            /* if (cn % 2 == 0)
             {
                 AdRequest adRequest = new AdRequest();
                 interstitialAd.ReceivedAd += OnAdReceived;
                 interstitialAd.LoadAd(adRequest);


             }*/


            t3.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));



            t4.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 237, 0));

            can.Children.Clear();

            var tex_effect = new BitmapImage(new Uri("/Images/str.jpg", UriKind.Relative));

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

            if (askforReview && MainPage.cn > 2)
            {


                //IsolatedStorageSettings.ApplicationSettings["done"] = true;
                //askforReview = false;
                var returnvalue = MessageBox.Show(content, caption, MessageBoxButton.OK);
                if (returnvalue == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["done"] = true;
                    askforReview = false;
                    IsolatedStorageSettings.ApplicationSettings["askforreview"] = askforReview;
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }

            }


        }

        /* protected override void OnNavigatedTo(NavigationEventArgs e)
         {
             base.OnNavigatedTo(e);

             if (IsolatedStorageFile.GetUserStoreForApplication().FileExists("photo.jpg"))
             {
                 IsolatedStorageFile Store = IsolatedStorageFile.GetUserStoreForApplication();
                 IsolatedStorageFileStream Stream = new IsolatedStorageFileStream("photo.jpg", FileMode.Open, FileAccess.Read, Store);

                 WriteableBitmap myImage = new WriteableBitmap((int)can.Width, (int)can.Height);
                 myImage.LoadJpeg(Stream);

                 i.Source = myImage;
                 i.InvalidateArrange();
                 Stream.Close();
             }


             if(MainPage.q)
             {
                 can.Children.Add(i);
             }
         }*/


        async void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                i = new Image();
                capt = new BitmapImage();
                MainPage.capt.SetSource(e.ChosenPhoto);



                source = new StreamImageSource(e.ChosenPhoto);
                fl_name = e.OriginalFileName;

                i.Source = MainPage.capt;
                i.Height = can.Height;
                i.Width = can.Width;

                i.Stretch = System.Windows.Media.Stretch.UniformToFill;
                //can.Height = i.Height;
                //can.Width = i.Width;
                can.Children.Add(i);

                MainPage.q = true;


                //t3.IsEnabled = true;
                t4.IsEnabled = true;


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


        private void save_btn(object sender, EventArgs e)
        {
            //cn++;
            if (!MainPage.q)
            {
                MessageBox.Show("Load an Image first");
            }
            else if (askforReview && MainPage.cn >= 1)
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
                    IsolatedStorageSettings.ApplicationSettings["askforreview"] = askforReview;
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


        private void next(object sender, EventArgs e)
        {
            //ShareLinkTask shareLinkTask = new ShareLinkTask();
            //shareLinkTask.Title = "Try this awesome REFLEXES + MEMORY GAME";
            //shareLinkTask.LinkUri = new Uri("http://www.windowsphone.com/en-in/search?q=kapil+bakshi", UriKind.Absolute);
            //shareLinkTask.Message = "My Level 2 score is " + score.ToString() + " This game is simply outstanding.Lets you test and improve your memory,reflexes and concentration.The challenging and extremely interesting levels just don't let you blink your eye and let you enjoy yourself to the fullest. ";
            //shareLinkTask.Show();

            //NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));


            //MainPage.nxt_cnt =0;

            //if (MainPage.nxt_cnt == 3)
            //{

            //    MainPage.nxt_cnt = 0;

            //    AdRequest adRequest = new AdRequest();
            //    adRequest.ForceTesting = true;
            //    interstitialAd.ReceivedAd += OnAdReceived;
            //    interstitialAd.LoadAd(adRequest);
            //}



            NavigationService.Navigate(new Uri("/interval_1.xaml", UriKind.Relative));
        }


        public string fl_name { get; set; }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            bool r = IsolatedStorageSettings.ApplicationSettings.Contains("mail");
            bool f = IsolatedStorageSettings.ApplicationSettings.Contains("r1");


            if (f && !r)
            {

                var returnvalue = MessageBox.Show("Don't forget to mention your country's name", "Write us a feedback and get a chance to win LUMIA 1020", MessageBoxButton.OK);

                if (returnvalue == MessageBoxResult.OK)
                {

                    IsolatedStorageSettings.ApplicationSettings["mail"] = true;

                    Microsoft.Phone.Tasks.EmailComposeTask emailTask = new Microsoft.Phone.Tasks.EmailComposeTask();
                    emailTask.Subject = "Suggestions for Greatest Photo Editor";
                    emailTask.To = "wpapps167@outlook.com";
                    emailTask.Body = "Name:-\r\nCountry:-\r\nfeedback:-";
                    emailTask.Show();
                }

            }

            base.OnNavigatedTo(e);

        }
    }
}