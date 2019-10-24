﻿using DoYouNowThese.CommonModel.Infrastructure;
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
                Button btnCategoryLink = new Button()
                {
                    Text = category.Name,
                    ImageSource = category.CategoryImagePath,
                    ClassId=category.CategoryId.ToString()
                };
                btnCategoryLink.Clicked += BtnCategoryLink_Clicked;
                stacklayout.Children.Add(btnCategoryLink);
            }

            this.Content = stacklayout;
        }

        private void BtnCategoryLink_Clicked(object sender, EventArgs e)
        {
            Button findButton = (Button)sender;
            if (findButton != null)
            {
                int categoryId = int.Parse(findButton.ClassId);
            }

             
        }
    }
}