namespace AirExchangerMobile.ViewModel.Plane
{
    public class PlaneDetailsPageViewModel : BaseViewModel
    {
        public Entities.Plane Plane { get; set; }
        public PlaneDetailsPageViewModel(Entities.Plane plane)
        {
            Title = $"#{plane.PlaneId} - {plane?.PlaneModel.Name}";
            Plane = plane;
        }
    }
}
