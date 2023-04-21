namespace HotelBookingApp.Repository
{
    public interface IUserService
    {
        string GetUserId();
        bool isAuthenticated();
    }
}
