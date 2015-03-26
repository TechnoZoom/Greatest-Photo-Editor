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

namespace imgeditor
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            this.textblock1.Text = "Version 1.0\r\n\r\nLets you apply breathtaking effects to your photos.\r\n\r\nBuilt by KAPIL BAKSHI\r\n© 2014 Kapil Bakshi All Rights Reserved ";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Suggestion_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Tasks.EmailComposeTask emailTask = new Microsoft.Phone.Tasks.EmailComposeTask();
            emailTask.Subject = "";
            emailTask.To = "akapil167@yahoo.com";
            emailTask.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rate(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();

        }
    }
}