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

namespace imgeditor
{
    public partial class ExitPage : PhoneApplicationPage
    {
        private InterstitialAd interstitialAd;
        public ExitPage()
        {
            InitializeComponent();

            interstitialAd = new InterstitialAd("ca-app-pub-1177092011471737/6260163404");

          AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = true;
            interstitialAd.ReceivedAd += OnAdReceived;
            //interstitialAd.FailedToReceiveAd += OnFailedToReceiveAd;
            interstitialAd.LoadAd(adRequest);
        

        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
            interstitialAd.ShowAd();
            
        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            
            /* AdRequest adRequest = new AdRequest();
             interstitialAd.ReceivedAd += OnAdReceived;
             interstitialAd.LoadAd(adRequest);*/


            Application.Current.Terminate();


            base.OnBackKeyPress(e);

        }

    }
}