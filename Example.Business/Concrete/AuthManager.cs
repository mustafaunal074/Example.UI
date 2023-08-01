using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Business.Abstract;
using Example.Entities.Dtos;
using Example.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Example.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public AuthManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<IdentityResult> Edit(UserUpdateDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            if (model.Password != null)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
            }

            var result = await _userManager.UpdateAsync(user);

            return result;
        }

        public async Task<SignInResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                return result;
            }

            return null;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDto model)
        {
            AppUser appIdentityUser = new AppUser { UserName = model.UserName, Email = model.Email };

            var result = await _userManager.CreateAsync(appIdentityUser, model.Password);

            return result;
        }
    }
}
