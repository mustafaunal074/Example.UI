using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Example.Business.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterDto model);
        Task<SignInResult> Login(LoginDto model);
        Task<IdentityResult> Edit(UserUpdateDto model);
        Task LogOut();
    }
}
