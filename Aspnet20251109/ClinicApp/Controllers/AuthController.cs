using ClinicApp.ViewModels;
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
    }
}
