using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirExchangerMobile.Entities;
using AirExchangerMobile.Helpers;
using AirExchangerMobile.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirExchangerMobile.Pages.Plane
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlane : ContentPage
    {
        public static IEnumerable<PlaneModel> PlaneModels { get; set; }

        public AddPlane()
        {
            InitializeComponent();
            PlaneModels = PlaneRequests.GetPlaneModels();

            foreach (var model in PlaneModels)
            {
                PlaneModelSelector.Items.Add(model.Name);
            }
        }

        private async void AddPlaneButton_Clicked(object sender, EventArgs e)
        {
            var planeModelId = PlaneModels.FirstOrDefault(x => x.Name == PlaneModelSelector.SelectedItem.ToString())
                                  ?.PlaneModelId ?? 0;

            var plane = new PlaneViewModel
            {
                PlaneModelId = planeModelId,
                CompanyId = CurrentUser.CurrentUserModel.UserId,
                CostPerFlight = double.Parse(PricePerFlight.Text),
                CountPlanes = int.Parse(CountPlanes.Text)
            };

            var isRobotAdd = PlaneRequests.AddPlane(plane);
            if (!isRobotAdd)
            {
                AddPlaneFailed.IsVisible = true;
            }
            else
            {
                ClearForm();
                MessagingCenter.Send(this, "AddPlane", plane);
                await Navigation.PopAsync();
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void ClearForm()
        {
            AddPlaneFailed.IsVisible = false;
            CountPlanes.Text = string.Empty;
            PricePerFlight.Text = string.Empty;
        }
    }
}