using AirExchangerMobile.Entities;

namespace AirExchangerMobile.ViewModel.Rents
{
    public class RentDetailsPageViewModel : BaseViewModel
    {
        public Rent Rent { get; set; }

        public RentDetailsPageViewModel(Rent rent)
        {
            Title = $"#{rent.CompanyId}";
            Rent = rent;
        }
    }
}
