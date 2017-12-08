using System;
using System.Collections.ObjectModel;
using AirExchangerMobile.Helpers;
using AirExchangerMobile.Model;
using AirExchangerMobile.ViewModel.Plane;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirExchangerMobile.Pages.Plane
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanesPage : ContentPage
    {
        private readonly PlanesPageViewModel _viewModel;

        public PlanesPage()
        {
            InitializeComponent();

            var planes = PlaneRequests.GetPlanesOfCompany(CurrentUser.CurrentUserModel.UserId);

            _viewModel = new PlanesPageViewModel
            {
                PlanesModel = new ObservableCollection<Entities.Plane>(planes)
            };

            BindingContext = _viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Entities.Plane;
            if (item == null)
                return;

            await Navigation.PushAsync(new PlaneDetails(new PlaneDetailsPageViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddPlane_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPlane());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.PlanesModel.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }

        private async void AddPlaneModel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPlaneModelPage());
        }

        private async void LogOff_OnClicked(object sender, EventArgs e)
        {
            CurrentUser.CurrentUserModel = null;
            await Navigation.PopAsync();
        }
    }
}