using ClinicApp.Helpers;
using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class AuthController : Controller {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM vm) {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user == null) {
                ModelState.AddModelError("Email", "Email or password are wrong");
                return View(vm);
            }

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, true, true);

            if(!result.Succeeded) {
                ModelState.AddModelError("Email", "Email or password are wrong");
                return View(vm);
            }

            return Redirect("/");
        }

        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        [Authorize(Roles = "APP_ADMIN")]
        public async Task<IActionResult> Create() {
            return View();
        }

        [Authorize(Roles = "APP_ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateVM vm) {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var user = new AppUser {
                Email = vm.Email,
                UserName = vm.Email.Split("@")[0]
            };

            if (vm.ProfilePicture != null && vm.ProfilePicture.Length > 0) {
                if (vm.ProfilePicture.Length > 256 * 1024) {
                    ModelState.AddModelError("ProfilePicture", "Max size is 256KB");
                    return View(vm);
                }

                var alllowedExt = new string[] { "image/jpg", "image/png" };
                if (!alllowedExt.Contains(vm.ProfilePicture.ContentType)) {
                    ModelState.AddModelError("ProfilePicture", "Only JPG and PNG images allowed");
                    return View(vm);
                }

                using var memory = new MemoryStream();
                vm.ProfilePicture.CopyTo(memory);
                user.ProfilePicture = memory.ToArray();
            }

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (!result.Succeeded) {
                ModelState.AddModelError(string.Empty, "Create user failed");
                return View(vm);
            }

            result = await _userManager.AddToRoleAsync(user, vm.Role);
            if (!result.Succeeded) {
                ModelState.AddModelError("Role", "Failed to add role");
                return View(vm);
            }


            return Redirect("/");
        }

        public async Task<IActionResult> Users() {
            var users = _userManager.Users.ToList();
            return View(users);
        }

    }
}
