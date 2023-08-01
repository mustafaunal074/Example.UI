using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Business.Abstract;
using Example.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        public IActionResult Register() // => public IActionResult Register() => View();
        {
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Register(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginDto { ReturnUrl = returnUrl });
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Login(model);

                if (result != null && result.Succeeded)
                {
                    return Redirect(model.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Böyle bir kullanıcı adı bulunmamaktadır.");
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _authService.LogOut();
            return RedirectToAction("Login");
        }
    }
}
