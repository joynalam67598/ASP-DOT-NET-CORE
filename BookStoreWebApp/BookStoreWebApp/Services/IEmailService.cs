using BookStoreWebApp.Model;
using System.Threading.Tasks;

namespace BookStoreWebApp.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEamilForConfirmationEmail(UserEmailOptions userEmailOptions);

        Task SendEamilForForgotPassword(UserEmailOptions userEmailOptions);
    }
}