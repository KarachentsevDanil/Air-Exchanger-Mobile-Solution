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
    public partial class AddPlaneModelPage : ContentPage
    {
        private readonly IEnumerable<PlaneType> _planeTypes;

        public AddPlaneModelPage()
        {
            InitializeComponent();
            _planeTypes = PlaneRequests.GetPlaneTypes();

            foreach (var type in _planeTypes)
            {
                PlaneTypeSelector.Items.Add(type.Name);
            }
        }

        private async void AddPlaneModelButton_Clicked(object sender, EventArgs e)
        {
            var planeTypeId = _planeTypes.FirstOrDefault(x => x.Name == PlaneTypeSelector.SelectedItem.ToString())
                                       ?.PlaneTypeId ?? 0;

            var planeModel = new PlaneModel
            {
                Name = Name.Text,
                Description = Description.Text,
                PlaneTypeId = planeTypeId,
                Capacity = int.Parse(Capacity.Text)
            };

            var isRobotAdd = PlaneRequests.AddPlaneModel(planeModel);
            if (!isRobotAdd)
            {
                AddPlaneModelFailed.IsVisible = true;
            }
            else
            {
                ClearForm();
                AddPlane.PlaneModels = PlaneRequests.GetPlaneModels();

                await Navigation.PopAsync();
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void ClearForm()
        {
            AddPlaneModelFailed.IsVisible = false;
            Name.Text = string.Empty;
            Description.Text = string.Empty;
        }
    }
}