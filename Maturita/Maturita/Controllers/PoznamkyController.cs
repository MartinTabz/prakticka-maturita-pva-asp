using Maturita.Data;
using Maturita.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maturita.Controllers
{
    public class PoznamkyController : Controller
    {
        private readonly UserManager<Uzivatel> _userManager;
        private readonly SignInManager<Uzivatel> _signInManager;
        private readonly ApplicationDbContext _context;

        public PoznamkyController(UserManager<Uzivatel> userManager, SignInManager<Uzivatel> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Prihlasit", "Profil");
            }

            var notes = await _context.Poznamky
              .Where(n => n.UzivatelId == user.Id)
              .ToListAsync();

            return View(notes);
        }
    }
}
