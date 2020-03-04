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
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            InitializeComponent();


            Application.Current.Properties["appUserId"] = null;
            Application.Current.Properties["token"] = null;
            Application.Current.SavePropertiesAsync();
            Navigation.PushAsync(new LeftMenu());
        }
    }
}