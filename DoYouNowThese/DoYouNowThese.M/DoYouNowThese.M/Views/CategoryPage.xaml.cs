using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.M.Dependencies;
using DoYouNowThese.PROVIDER.Providers.CategoryOperation;
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
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            CategoryProvider categoryOperation = new CategoryProvider();

            StackLayout stacklayout = new StackLayout();

            InfrastructureModel<List<Category>> data = categoryOperation.GetInformationContentSingleData(TokenAccesModel.accesValue);
            foreach (var category in data.ResultModel)
            {
                Button button = new Button()
                {
                    Text = category.Name,
                    ImageSource = category.CategoryImagePath
                };
                stacklayout.Children.Add(button);
            }

            this.Content = stacklayout;
        }
    }
}