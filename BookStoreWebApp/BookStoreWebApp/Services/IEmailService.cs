using BookStoreWebApp.Model;
using System.Threading.Tasks;

namespace BookStoreWebApp.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendConfirmationEmail(UserEmailOptions userEmailOptions);
    }
}