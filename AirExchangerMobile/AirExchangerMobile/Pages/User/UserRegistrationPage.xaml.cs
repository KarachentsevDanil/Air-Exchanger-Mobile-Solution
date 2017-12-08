using System;
using AirExchangerMobile.Entities;
using AirExchangerMobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirExchangerMobile.Pages.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegistrationPage : ContentPage
    {
        public UserRegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var company = new Company
            {
                Name = Name.Text,
                Email = Email.Text,
                Password = Password.Text
            };

            var isSuccessed = CompanyRequests.Register(company);
            if (!isSuccessed)
            {
                RegisterFailed.IsVisible = true;
            }
            else
            {
                RegisterFailed.IsVisible = false;
                await Navigation.PopAsync();
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}