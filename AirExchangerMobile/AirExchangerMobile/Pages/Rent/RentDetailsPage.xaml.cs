using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirExchangerMobile.ViewModel.Rents;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirExchangerMobile.Pages.Rent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentDetailsPage : ContentPage
    {
        public RentDetailsPageViewModel RentDetailsPageModel { get; set; }

        public RentDetailsPage()
        {
            InitializeComponent();
        }

        public RentDetailsPage(RentDetailsPageViewModel model)
        {
            InitializeComponent();
            RentDetailsPageModel = model;
            BindingContext = RentDetailsPageModel;
        }
    }
}