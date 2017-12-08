using AirExchangerMobile.Pages.User;
using Xamarin.Forms;

namespace AirExchangerMobile.Pages.Common
{
    public class MainLayoutPage : TabbedPage
    {
        public MainLayoutPage()
        {
            Page loginPage = new NavigationPage(new UserLoginPage())
            {
                Title = "Sign in to account"
            };

            Children.Add(loginPage);
            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}