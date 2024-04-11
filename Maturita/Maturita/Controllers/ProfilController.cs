using Maturita.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Maturita.Data;
using Maturita.Models;

namespace Maturita.Controllers
{
    public class ProfilController : Controller
    {
        private readonly UserManager<Uzivatel> _userManager;
        private readonly SignInManager<Uzivatel> _signInManager;
        private readonly ApplicationDbContext _context;

        public ProfilController(UserManager<Uzivatel> userManager, SignInManager<Uzivatel> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }

            return RedirectToAction("Prihlasit");
        }

        public IActionResult Registrovat()
        {
            var response = new RegistrovatViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrovat(RegistrovatViewModel registrovatViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registrovatViewModel);
            }

            var user = await _userManager.FindByNameAsync(registrovatViewModel.UserName);
            if (user != null)
            {
                TempData["Error"] = "Toto uživatelské jméno je již využité";
                return View(registrovatViewModel);
            }

            var newUser = new Uzivatel()
            {
                UserName = registrovatViewModel.UserName,
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registrovatViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                return RedirectToAction("Prihlasit", "Profil");
            }
            else
            {
                TempData["Error"] = newUserResponse.Errors.First().Description;
                return View(registrovatViewModel);
            }
        }

        public IActionResult Prihlasit()
        {
            var response = new PrihlasitViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Prihlasit(PrihlasitViewModel prihlasitViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(prihlasitViewModel);
            }

            var user = await _userManager.FindByNameAsync(prihlasitViewModel.UserName);

            if (user == null)
            {
                TempData["Error"] = "Špatné údaje";
                return View(prihlasitViewModel);
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, prihlasitViewModel.Password);

            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, prihlasitViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profil");
                }
                else
                {
                    TempData["Error"] = "Špatné údaje";
                    return View(prihlasitViewModel);
                }
            }
            TempData["Error"] = "Špatné údaje";
            return View(prihlasitViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Odhlasit()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
