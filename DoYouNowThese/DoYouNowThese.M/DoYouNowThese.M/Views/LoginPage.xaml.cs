using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.M.Dependencies;
using DoYouNowThese.PROVIDER.Providers.AppUserOperation;
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
    public partial class LoginPage : ContentPage
    {
        AppUserProvider appUserProvider;
        public LoginPage()
        {
            InitializeComponent();
            appUserProvider = new AppUserProvider();
            btnLogin.Clicked += BtnLogin_Clicked;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            AppUserLoginModel appUserLoginModel = new AppUserLoginModel()
            {
                UserName = ent_UserName.Text,
                Password=ent_Password.Text,
            };

            AppUserModel appuserModel = appUserProvider.GetLoginUser(appUserLoginModel).ResultModel;

            if (appuserModel != null)
            {
                Application.Current.Properties["appUserId"] = appuserModel.AppUser.AppUserId;
                Application.Current.SavePropertiesAsync();
                Navigation.PushModalAsync(new LeftMenu());
            }
            else
            {
                DisplayAlert("Hata", "Kullanıcı Adı Veya Şifre Doğru Değil", "Tekrar Dene");
            }

        }
    }
}