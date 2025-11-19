using ClinicApp.Helpers;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class AuthController : Controller {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
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

            var user = new IdentityUser {
                Email = vm.Email,
                UserName = vm.Email.Split("@")[0]
            };

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

    }
}
