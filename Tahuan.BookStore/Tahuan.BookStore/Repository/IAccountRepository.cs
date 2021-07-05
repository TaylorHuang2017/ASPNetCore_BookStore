using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tahuan.BookStore.Models;

namespace Tahuan.BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignupUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
    }
}