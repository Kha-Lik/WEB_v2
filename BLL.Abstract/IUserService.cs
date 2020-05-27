using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> Register(UserRegistrationModel model);

        Task<SignInResult> Login(UserLoginModel model);

        Task SignOut();

        Task<bool> IsEmailConfirmed(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, string code);

        Task<User> GetUserByClaims(ClaimsPrincipal claims);
    }

    
}