using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.DATA.Models;
using DoYouNowThese.M.Operations.CategoryOperation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoYouNowThese.M.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class CategoryPage : ContentView
    {
        public CategoryPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //CategoryProvider categoryOperation = new CategoryProvider();

            //StackLayout stacklayout = new StackLayout();

            //InfrastructureModel<List<Category>> data = categoryOperation.GetInformationContentSingleData();
            //foreach (var category in data.ResultModel)
            //{
            //    Button button = new Button()
            //    {
            //        Text=category.Name,
            //        ImageSource=category.CategoryImagePath
            //    };
            //    stacklayout.Children.Add(button);
            //}

            //this.Content = stacklayout;
        }


    }
}