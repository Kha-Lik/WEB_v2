using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Abstract;
using BLL.Models;
using DAL.Abstract;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public UserService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<UserIdentityResult> Register(UserRegistrationModel model)
        {
            var user = _mapper.Map<User>(model);
            var userIdentityResult = new UserIdentityResult();
            userIdentityResult.Result = await _unit.UserManager.CreateAsync(user, model.Password);
            userIdentityResult.User = user;
            return userIdentityResult;
        }

        public async Task<SignInResult> Login(UserLoginModel model)
        {
            var result =
                await _unit.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            return result;
        }

        public async Task SignOut()
        {
            await _unit.SignInManager.SignOutAsync();
        }

        public async Task<bool> IsEmailConfirmed(User user)
        {
            return await _unit.UserManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string code)
        {
            return await _unit.UserManager.ConfirmEmailAsync(user, code);
        }

        public async Task<User> GetUserByClaims(ClaimsPrincipal claims)
        {
            return await _unit.UserManager.GetUserAsync(claims);
        }
    }
}