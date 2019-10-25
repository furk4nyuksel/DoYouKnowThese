using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.M.Dependencies;
using DoYouNowThese.PROVIDER.Providers.InformationContentOperation;
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
    public partial class MainPageCategory : ContentPage
    {
        int categoryglobalId = 0;
        public MainPageCategory(int categoryId=0)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            categoryglobalId = categoryId;
            InformationContentProvider informationContentProvider = new InformationContentProvider();

            //Todo:Dön burada appuserId yok
            InformationContentPostModel postModel = new InformationContentPostModel()
            {
                TokenKey = TokenAccesModel.accesValue,
                CategoryId = categoryId,
                AppUserId = 0
            };
            ///sayfaya yönlendir devam et

            InfrastructureModel<InformationContentSingleDataModel> informationContentSingleDataModelList = new InfrastructureModel<InformationContentSingleDataModel>();

            informationContentSingleDataModelList = informationContentProvider.GetInformationCategoryContentSingleData(postModel);

            lblExplanation.Text = informationContentSingleDataModelList.ResultModel.Explanation;
            lblTitle.Text = informationContentSingleDataModelList.ResultModel.Title;
            imgContent.Source = informationContentSingleDataModelList.ResultModel.ImagePath;

            btnChangeSingleData.Clicked += BtnChangeSingleData_Clicked;
        }

        private async void BtnChangeSingleData_Clicked(object sender, EventArgs e)
        {
            InformationContentProvider informationContentProvider = new InformationContentProvider();

            //Todo:Dön burada appuserId yok
            InformationContentPostModel postModel = new InformationContentPostModel()
            {
                TokenKey = TokenAccesModel.accesValue,
                CategoryId = categoryglobalId,
                AppUserId = 0
            };
            ///sayfaya yönlendir devam et

            InfrastructureModel<InformationContentSingleDataModel> informationContentSingleDataModelList = new InfrastructureModel<InformationContentSingleDataModel>();

            informationContentSingleDataModelList = informationContentProvider.GetInformationCategoryContentSingleData(postModel);

            lblExplanation.Text = informationContentSingleDataModelList.ResultModel.Explanation;
            lblTitle.Text = informationContentSingleDataModelList.ResultModel.Title;
            imgContent.Source = informationContentSingleDataModelList.ResultModel.ImagePath;
        }
    }
}