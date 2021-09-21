using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApp.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}