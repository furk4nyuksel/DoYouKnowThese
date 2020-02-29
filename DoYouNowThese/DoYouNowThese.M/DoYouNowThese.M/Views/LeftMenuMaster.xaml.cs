using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoYouNowThese.M.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeftMenuMaster : ContentPage
    {
        public ListView ListView;

        public LeftMenuMaster()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new LeftMenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        class LeftMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<LeftMenuMasterMenuItem> MenuItems { get; set; }

            public LeftMenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<LeftMenuMasterMenuItem>(new[]
                {
                    new LeftMenuMasterMenuItem { Id = 0, Title = "İçerikler",TargetType=new MainPage().GetType() },
                    new LeftMenuMasterMenuItem { Id = 1, Title = "İçerik Gönder" },
                    new LeftMenuMasterMenuItem { Id = 2, Title = "Hakkımızda" },
                    new LeftMenuMasterMenuItem { Id = 3, Title = "Kategoriye Göre İçerik",TargetType=new CategoryPage().GetType() },
                });

                MenuItems.Add(new LeftMenuMasterMenuItem() { Id = 5, Title = "Giriş Yap",TargetType=new LoginPage().GetType() });
                MenuItems.Add(new LeftMenuMasterMenuItem() { Id = 6, Title = "Kayıt Ol",TargetType=new RegisterPage().GetType() });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}