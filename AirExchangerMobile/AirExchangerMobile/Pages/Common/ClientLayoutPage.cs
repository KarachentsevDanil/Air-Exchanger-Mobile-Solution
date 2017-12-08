using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirExchangerMobile.Pages.Plane;
using AirExchangerMobile.Pages.Rent;
using Xamarin.Forms;

namespace AirExchangerMobile.Pages.Common
{
    public class ClientLayoutPage : TabbedPage
    {
        public ClientLayoutPage()
        {

            Page planesPage = new NavigationPage(new PlanesPage())
            {
                Title = "My planes"
            };

            Page rentsPage = new NavigationPage(new RentsPage())
            {
                Title = "My rents"
            };

            Children.Add(planesPage);
            Children.Add(rentsPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}