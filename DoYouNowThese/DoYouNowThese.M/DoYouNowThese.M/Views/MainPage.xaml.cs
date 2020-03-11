using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.M.Dependencies;
using DoYouNowThese.PROVIDER.Providers.InformationContentOperation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoYouNowThese.M
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //InformationContentOperation informationContentOperation = new InformationContentOperation();

            //InfrastructureModel<InformationContentSingleDataModel> data = informationContentOperation.GetInformationContentSingleData();

            //lblExplanation.Text = data.ResultModel.Explanation;
            //lblTitle.Text = data.ResultModel.Title;
            //imgContent.Source = data.ResultModel.ImagePath;


            btnChangeSingleData.Clicked += BtnChangeSingleData_Clicked;
        }

        private void BtnChangeSingleData_Clicked(object sender, EventArgs e)
        {
            InformationContentProvider informationContentProvider = new InformationContentProvider();
            int appuserId = Application.Current.Properties["appUserId"] != null ? (int)Application.Current.Properties["appUserId"] : 0;
            var data = informationContentProvider.GetInformationContentSingleData(new InformationContentPostModel() { TokenKey= TokenAccesModel.accesValue,AppUserId= appuserId });

            lblExplanation.Text = data.ResultModel.Explanation;
            lblTitle.Text = data.ResultModel.Title;
            ImgPostSource.Source = data.ResultModel.ImagePath;
            contentPage.BackgroundImageSource= data.ResultModel.ImagePath;
        }

    }
}
