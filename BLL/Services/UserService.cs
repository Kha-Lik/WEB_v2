using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Register(UserRegistrationModel model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _unit.UserManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<SignInResult> Login(UserLoginModel model)
        {
            var result = await _unit.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            return result;
        }

        public async Task SignOut()
        {
            await _unit.SignInManager.SignOutAsync();
        }
    }
}