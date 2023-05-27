using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Enums;
using WebAnimalPassport.Models.View.Animal;

namespace WebAnimalPassport.Controllers
{
    public sealed class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        public AnimalController(ApplicationDbContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        #region List
        public async Task<IActionResult> List()
        {
            List<Animal> list = new List<Animal>()
            {
                new Animal()
                {
                    Name = "Тест 1",
                    Type = AnimalType.Cat,
                },
                new Animal()
                {
                    Name = "Тест 2",
                    Type = AnimalType.Dog,
                }
            };
            //string? userId = _userManager.GetUserId(User);
            //if (userId == null)
            //{
            //    return Forbid();
            //}
            //List<Animal> list = await _context.Animals
            //    .Include(x => x.User)
            //    .Where(x=>x.User.Id == userId)
            //    .ToListAsync();
            return View(list);
        }
        #endregion
        #region Index
        public async Task<IActionResult> Index(long id)
        {
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.Owners)
                .Include(x => x.InitialUser)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (found == null)
            {
                return NotFound();
            }
            return View(found);
        }
        #endregion
        #region Create
        public IActionResult Create()
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalCreateModel model)
        {
            CustomUser? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Forbid();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Animal animal = new Animal(model);
            animal.User = user;
            animal.InitialUser = user;
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { animal.Id });
        }
        #endregion
        #region Edit
        public async Task<IActionResult> Edit(long id)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            AnimalEditModel model = new AnimalEditModel(found);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AnimalEditModel model)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            Animal animal = new Animal(model);
            found.Update(animal);
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { animal.Id });
        }
        #endregion
        #region Transmit
        public async Task<IActionResult> Transmit(long id)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            AnimalTransmitModel model = new AnimalTransmitModel()
            {
                AnimalId = id,
                AnimalName = found.Name,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transmit(AnimalTransmitModel model)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            CustomUser? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.OtherUserId);
            if (user == null)
            {
                ModelState.AddModelError("OtherUserId", "Пользотель с этим Id не найден!");
            }
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            return RedirectToAction("List");
        }
        #endregion
        #region Death
        #endregion
    }
}
