using DoYouNowThese.CommonModel.InformationContentModel;
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
            ChangeData();
            btnChangeSingleData.Clicked += BtnChangeSingleData_Clicked;
        }

        private void BtnChangeSingleData_Clicked(object sender, EventArgs e)
        {

            InformationContentOperation informationContentOperation = new InformationContentOperation();
            Task<InformationContentSingleDataModel> taskData = Task<InformationContentOperation>.Run(() => informationContentOperation.GetInformationContentSingleData().Result);

            InformationContentSingleDataModel data = taskData.Result;

            lblExplanation.Text = data.Explanation;
            lblTitle.Text = data.Title;
            imgContent.Source = data.ImagePath;

            btnChangeSingleData.Clicked += BtnChangeSingleData_Clicked;
        }
        public async void ChangeData()
        {
            InformationContentOperation informationContentOperation = new InformationContentOperation();
            Task<InformationContentSingleDataModel> taskData = Task<InformationContentOperation>.Run(() => informationContentOperation.GetInformationContentSingleData().Result);
            if (taskData.Status == TaskStatus.RanToCompletion)
            {
                InformationContentSingleDataModel data = taskData.Result;

                lblExplanation.Text = data.Explanation;
                lblTitle.Text = data.Title;
                imgContent.Source = data.ImagePath;
            }
        }
    }
}
