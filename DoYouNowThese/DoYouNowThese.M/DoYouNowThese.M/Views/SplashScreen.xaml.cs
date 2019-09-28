using DoYouNowThese.M.Operations.TokenOperation;
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
        TokenOperation tokenOperation;
        public SplashScreen()
        {
            InitializeComponent();

            tokenOperation = new TokenOperation();
            if (!App.Current.Properties.ContainsKey("token"))
            {
                string token = tokenOperation.GetAnonimToken();
                Application.Current.Properties["token"] = token;
                Application.Current.SavePropertiesAsync();
            }
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