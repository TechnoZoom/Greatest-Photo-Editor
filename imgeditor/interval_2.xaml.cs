using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GoogleAds;
using System.IO.IsolatedStorage;

namespace imgeditor
{
    public partial class interval_2 : PhoneApplicationPage
    {
        private InterstitialAd interstitialAd;
        private bool t;
        private bool p;
        public interval_2()
        {
            InitializeComponent();
            IsolatedStorageSettings.ApplicationSettings["r2"] = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            interstitialAd = new InterstitialAd("ca-app-pub-1177092011471737/6260163404");



            
            MainPage.nxt_cnt = 0;

            if (!t)
            {
                AdRequest adRequest = new AdRequest();
                adRequest.ForceTesting = true;
                interstitialAd.ReceivedAd += OnAdReceived;
                interstitialAd.FailedToReceiveAd += OnFailedToReceiveAd;
                interstitialAd.LoadAd(adRequest);
                t = true;
            }

        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
            interstitialAd.ShowAd();
            p = true;
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

            if (p) { 
            NavigationService.Navigate(new Uri("/Page6.xaml", UriKind.Relative));
        }

        }

        private void OnFailedToReceiveAd(object sender, AdErrorEventArgs errorCode)
        {
            p = true;
        }

        private void prev(object sender, EventArgs e)
        {
            /* if (this.NavigationService.CanGoBack)

              {

                  this.NavigationService.GoBack();

             }*/

            NavigationService.Navigate(new Uri("/Page5.xaml", UriKind.Relative));


        }

    }
}