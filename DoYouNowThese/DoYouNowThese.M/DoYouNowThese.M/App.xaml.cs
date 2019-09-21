using DoYouNowThese.M.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoYouNowThese.M
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LeftMenu();
        }

        protected override void OnStart()
        {
            AppCenter.Start("473680cd-d2cf-4fd5-a6c5-b9032065f975",
                      typeof(Analytics), typeof(Crashes));
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
