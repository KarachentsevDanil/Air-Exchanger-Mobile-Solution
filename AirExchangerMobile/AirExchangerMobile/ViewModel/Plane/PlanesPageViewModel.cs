using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using AirExchangerMobile.Helpers;
using AirExchangerMobile.Model;
using AirExchangerMobile.Pages.Plane;
using Xamarin.Forms;

namespace AirExchangerMobile.ViewModel.Plane
{
    public class PlanesPageViewModel : BaseViewModel
    {
        public ObservableCollection<Entities.Plane> PlanesModel { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PlanesPageViewModel()
        {
            Title = "My Planes";
            PlanesModel = new ObservableCollection<Entities.Plane>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);

            MessagingCenter.Subscribe<AddPlane, PlaneViewModel>(this, "AddPlane", (obj, item) =>
            {
                RefreshData();
            });
        }

        public void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void RefreshData()
        {
            var planes = PlaneRequests.GetPlanesOfCompany(CurrentUser.CurrentUserModel.UserId);
            foreach (var plane in planes)
            {
                if (PlanesModel.All(x => x.PlaneId != plane.PlaneId))
                {
                    PlanesModel.Add(plane);
                }
            }
        }
    }
}
