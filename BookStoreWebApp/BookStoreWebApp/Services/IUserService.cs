namespace BookStoreWebApp.Services
{
    public interface IUserService
    {
        string GetUserID();
        bool IsAuthenticated();
    }
}