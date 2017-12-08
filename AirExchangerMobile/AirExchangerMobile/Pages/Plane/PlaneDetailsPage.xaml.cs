using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirExchangerMobile.ViewModel.Plane;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirExchangerMobile.Pages.Plane
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaneDetails : ContentPage
    {
        public PlaneDetailsPageViewModel PlaneModel { get; set; }

        public PlaneDetails()
        {
            InitializeComponent();
        }

        public PlaneDetails(PlaneDetailsPageViewModel model)
        {
            InitializeComponent();
            PlaneModel = model;
            BindingContext = PlaneModel;
        }
    }
}