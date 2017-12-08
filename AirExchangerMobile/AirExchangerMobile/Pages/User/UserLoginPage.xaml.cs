using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirExchangerMobile.Entities;
using AirExchangerMobile.Helpers;
using AirExchangerMobile.Model;
using AirExchangerMobile.Pages.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirExchangerMobile.Pages.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLoginPage : ContentPage
    {
        public UserLoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var loginModel = new Company
            {
                Email = Email.Text,
                Password = Password.Text
            };

            var isSuccess = CompanyRequests.Login(loginModel);
            if (!isSuccess)
            {
                LoginInfo.IsVisible = true;
            }
            else
            {
                LoginInfo.IsVisible = false;
                CurrentUser.CurrentUserModel = CompanyRequests.GetCurrentUser();
                await Navigation.PushModalAsync(new ClientLayoutPage());
            }
        }

        private async void ReginstrationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegistrationPage());
        }
    }
}