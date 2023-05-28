using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.View.Animal;

namespace WebAnimalPassport.Controllers
{
    public sealed class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public AnimalController(ApplicationDbContext context, UserManager<CustomUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        #region List
        public async Task<IActionResult> List()
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            List<Animal> list = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.Owners)
                .ThenInclude(x=>x.User)
                .Where(x => x.User.Id == userId || x.Owners.Any(x=>x.User.Id == userId))
                .ToListAsync();
            return View(list);
        }
        #endregion

        #region ListLost
        public async Task<IActionResult> ListLost()
        {
            List<Animal> list = await _context.Animals.Where(x=>x.LostLocation != null && x.DeathDate == null).ToListAsync();
            return View(list);
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(long id)
        {
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.Notes)
                .Include(x => x.Owners.OrderBy(x=>x.TransmitDate))
                .Include(x => x.Vaccinations.OrderBy(x => x.StartDate))
                .ThenInclude(x => x.Doctor)
                .Include(x => x.Treatments.OrderBy(x => x.DateTime))
                .ThenInclude(x => x.Doctor)
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
                return Forbid();
            }
            Animal animal = new Animal(model);
            animal.User = user;
            animal.InitialUser = user;
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Animals/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Animals/{guid}{extension}";
                }
                try
                {
                    using (FileStream createStream = new FileStream(completePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(createStream);
                    }
                }
                catch
                {
                    ModelState.AddModelError("File", "Ошибка загрузки файла!");
                }
                animal.PhotoPath = $"{guid}{extension}";
            }
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
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
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.InitialUser)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Animals/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Animals/{guid}{extension}";
                }
                try
                {
                    using (FileStream createStream = new FileStream(completePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(createStream);
                    }
                    if (found.PhotoPath != null && System.IO.File.Exists($"{_env.WebRootPath}/src/Animals/{found.PhotoPath}"))
                    {
                        System.IO.File.Delete($"{_env.WebRootPath}/src/Animals/{found.PhotoPath}");
                    }
                }
                catch
                {
                    ModelState.AddModelError("File", "Ошибка загрузки файла!");
                }
                found.PhotoPath = $"{guid}{extension}";
            }
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }

            Animal animal = new Animal(model);
            found.Update(animal);
            _context.Animals.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { found.Id });
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
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.InitialUser)
                .FirstOrDefaultAsync(x => x.Id == model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            if (ModelState.ErrorCount > 0)
            {
                model.AnimalName = found.Name;
                return View(model);
            }
            OwnerHistory history = new OwnerHistory()
            {
                Animal = found,
                User = found.User,
                Reason = model.Reason,
                TransmitDate = DateTime.Now,
            };
            found.User = user;
            _context.Animals.Update(found);
            await _context.History.AddAsync(history);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
        #endregion

        #region Death
        public async Task<IActionResult> Death(long id)
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
            AnimalDeathModel model = new AnimalDeathModel()
            {
                AnimalId = id,
                AnimalName = found.Name,
                Date = DateTime.Today
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Death(AnimalDeathModel model)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.InitialUser)
                .FirstOrDefaultAsync(x => x.Id == model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            if (ModelState.ErrorCount > 0)
            {
                model.AnimalName = found.Name;
                return View(model);
            }
            found.LostLocation = null;
            found.DeathDate = model.Date;
            _context.Animals.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { found.Id });
        }
        #endregion

        #region Lost
        public async Task<IActionResult> Lost(long id)
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
            AnimalLostModel model = new AnimalLostModel()
            {
                AnimalId = id,
                AnimalName = found.Name,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lost(AnimalLostModel model)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.InitialUser)
                .FirstOrDefaultAsync(x => x.Id == model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            if (ModelState.ErrorCount > 0)
            {
                model.AnimalName = found.Name;
                return View(model);
            }
            found.LostLocation = model.Location;
            _context.Animals.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { found.Id });
        }
        #endregion

        #region Found
        public async Task<IActionResult> Found(long id)
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
            AnimalFoundModel model = new AnimalFoundModel()
            {
                AnimalId = id,
                AnimalName = found.Name,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Found(AnimalFoundModel model)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            Animal? found = await _context.Animals
                .Include(x => x.User)
                .Include(x => x.InitialUser)
                .FirstOrDefaultAsync(x => x.Id == model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            if (found.User.Id != userId)
            {
                return Forbid();
            }
            if (ModelState.ErrorCount > 0)
            {
                model.AnimalName = found.Name;
                return View(model);
            }
            found.LostLocation = null;
            _context.Animals.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { found.Id });
        }
        #endregion
    }
}
