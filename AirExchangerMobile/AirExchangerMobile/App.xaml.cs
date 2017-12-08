using AirExchangerMobile.Pages.Common;
using Xamarin.Forms;

namespace AirExchangerMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainLayoutPage();
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
