using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signinmanager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> usermanager, IMapper mapper, SignInManager<AppUser> signinmanager, RoleManager<IdentityRole> roleManager)
        {
            _usermanager = usermanager;
            _mapper = mapper;
            _signinmanager = signinmanager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserDto appUserDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bos input olmaz");
                return View(appUserDto);
            }
            if (appUserDto.Password != appUserDto.PasswordConfirm)
            {
                ModelState.AddModelError(string.Empty, "Tekrar password ile password eyni olmalidr");
                return View(appUserDto);
            }
            AppUser appUser = _mapper.Map<AppUser>(appUserDto);
            var res = await _usermanager.CreateAsync(appUser, appUserDto.Password);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Smth went wrong");
                return View(appUserDto);
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bos input olmaz");
                return View(appUserLoginDto);
            }
            AppUser appUser = await _usermanager.FindByNameAsync(appUserLoginDto.UserName);
            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Smth went wrong");
                return View(appUserLoginDto);
            }
            var res = await _signinmanager.PasswordSignInAsync(appUser, appUserLoginDto.Password, true, true);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Smth went wrong");
                return View(appUserLoginDto);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
        //public async Task CreateRole()
        //{
        //    await  _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await  _roleManager.CreateAsync(new IdentityRole { Name = "Users" });
        //}

        public async Task CreateAdmin()
        {
            AppUser appUser = new AppUser();
            appUser.FirstName = "Hesenov Huseyn";
            appUser.LastName = "HuseynAdmin";
            appUser.UserName = "Admin";
            appUser.Email = "Admin12@com";
            await _usermanager.CreateAsync(appUser, "Admin123!");
            await _usermanager.AddToRoleAsync(appUser, "Admin");

        }

    }
}
