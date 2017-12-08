using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using AirExchangerMobile.Entities;
using AirExchangerMobile.Helpers;
using AirExchangerMobile.Model;
using AirExchangerMobile.Pages.Rent;
using Xamarin.Forms;

namespace AirExchangerMobile.ViewModel.Rents
{
    public class RentsPageViewModel : BaseViewModel
    {
        public ObservableCollection<Rent> RentsModel { get; set; }
        public Command LoadRentsCommand { get; set; }

        public RentsPageViewModel()
        {
            Title = "My Rents";
            RentsModel = new ObservableCollection<Rent>();
            LoadRentsCommand = new Command(ExecuteLoadItemsCommand);

            MessagingCenter.Subscribe<AddRent, RentViewModel>(this, "AddRent", (obj, item) =>
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
            var rents = RentRequest.GetRentsOfCompany(CurrentUser.CurrentUserModel.UserId);
            foreach (var rent in rents)
            {
                if (RentsModel.All(x => x.RentId != rent.RentId))
                {
                    RentsModel.Add(rent);
                }
            }
        }
    }
}
