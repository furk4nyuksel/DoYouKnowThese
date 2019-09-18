using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.CommonModel.Infrastructure;
using DoYouNowThese.M.Operations.InformationContentOperation;
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
            InformationContentOperation informationContentOperation = new InformationContentOperation();
 
                InfrastructureModel<InformationContentSingleDataModel> data = informationContentOperation.GetInformationContentSingleData();

                lblExplanation.Text = data.ResultModel.Explanation;
                lblTitle.Text = data.ResultModel.Title;
                imgContent.Source = data.ResultModel.ImagePath;
       

            btnChangeSingleData.Clicked += BtnChangeSingleData_Clicked;
        }

        private void BtnChangeSingleData_Clicked(object sender, EventArgs e)
        {
            InformationContentOperation informationContentOperation = new InformationContentOperation();

            InfrastructureModel<InformationContentSingleDataModel> data = informationContentOperation.GetInformationContentSingleData();

            lblExplanation.Text = data.ResultModel.Explanation;
            lblTitle.Text = data.ResultModel.Title;
            imgContent.Source = data.ResultModel.ImagePath;

            btnChangeSingleData.Clicked += BtnChangeSingleData_Clicked;
        }
        
    }
}
