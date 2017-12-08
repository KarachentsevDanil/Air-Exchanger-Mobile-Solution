using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirExchangerMobile.Helpers;
using AirExchangerMobile.Model;
using AirExchangerMobile.Pages.Plane;
using AirExchangerMobile.ViewModel.Plane;
using AirExchangerMobile.ViewModel.Rents;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirExchangerMobile.Pages.Rent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentsPage : ContentPage
    {
        private readonly RentsPageViewModel _viewModel;

        public RentsPage()
        {
            InitializeComponent();

            var rents = RentRequest.GetRentsOfCompany(CurrentUser.CurrentUserModel.UserId);

            _viewModel = new RentsPageViewModel
            {
                RentsModel = new ObservableCollection<Entities.Rent>(rents)
            };

            BindingContext = _viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Entities.Rent;
            if (item == null)
                return;

            await Navigation.PushAsync(new RentDetailsPage(new RentDetailsPageViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.RentsModel.Count == 0)
                _viewModel.LoadRentsCommand.Execute(null);
        }

        private async void LogOff_OnClicked(object sender, EventArgs e)
        {
            CurrentUser.CurrentUserModel = null;
            await Navigation.PopAsync();
        }
    }
}