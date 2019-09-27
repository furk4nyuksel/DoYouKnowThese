using DoYouNowThese.M.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
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

            MainPage = new SplashScreen();
        }

        protected override void OnStart()
        {
            //AppCenter.Start("android=6aa0fc71-acb1-4012-aeb7-7162938abe87;" +
            //        "uwp={Your UWP App secret here};" +
            //        "ios={Your iOS App secret here}",
            //        typeof(Analytics), typeof(Crashes));
            //// Handle when your app starts
            ///
            AppCenter.Start("8f04c7f6-817a-48e8-882a-dbaa6a479806", typeof(Push));
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
