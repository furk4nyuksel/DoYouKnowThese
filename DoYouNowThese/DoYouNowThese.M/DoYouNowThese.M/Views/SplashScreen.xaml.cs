using DoYouNowThese.PROVIDER.TokenOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoYouNowThese.M.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        TokenProvider tokenProvider;
        public SplashScreen()
        {
            InitializeComponent();

            tokenProvider = new TokenProvider();
            string token = tokenProvider.GetAnonimToken();
            Application.Current.Properties["token"] = token;
            Application.Current.SavePropertiesAsync();

            LogoAnimation();
        }

        public async Task LogoAnimation()
        {
            imgLogo.Opacity = 0;

            await imgLogo.FadeTo(1, 2000);
            Application.Current.MainPage = new LeftMenu();
        }

    }
}