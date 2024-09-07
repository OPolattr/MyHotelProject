using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel viewModel = new UserEditViewModel();
            viewModel.Name = user.AppUserName;
            viewModel.Surname = user.AppUserSurname;
            viewModel.Username = user.AppUserName;
            viewModel.Email = user.Email;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if(userEditViewModel.Password == userEditViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.AppUserName = userEditViewModel.Name;
                user.AppUserSurname = userEditViewModel.Surname;
                user.Email = userEditViewModel.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Çıkıştan sonra ana sayfaya yönlendirme
        }
    }
}
