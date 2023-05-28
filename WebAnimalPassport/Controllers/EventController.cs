using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data;
using WebAnimalPassport.Models.Data.Event;
using WebAnimalPassport.Models.View.Event;

namespace WebEventPassport.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public EventController(ApplicationDbContext context, UserManager<CustomUser> userManager, IWebHostEnvironment env)
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
            List<Event> list = await _context.Events
                .Include(x => x.User)
                .ToListAsync();
            return View(list);
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index(long id)
        {
            Event? found = await _context.Events
                .Include(x => x.User)
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
        public async Task<IActionResult> Create(EventCreateModel model)
        {
            CustomUser? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Forbid();
            }
            Event eventEv = new Event(model);
            eventEv.User = user;
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Events/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Events/{guid}{extension}";
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
                eventEv.PhotoPath = $"{guid}{extension}";
            }
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            await _context.Events.AddAsync(eventEv);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { eventEv.Id });
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
            Event? found = await _context.Events
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
            EventEditModel model = new EventEditModel(found);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventEditModel model)
        {
            string? userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Forbid();
            }
            Event? found = await _context.Events
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
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Events/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Events/{guid}{extension}";
                }
                try
                {
                    using (FileStream createStream = new FileStream(completePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(createStream);
                    }
                    if (found.PhotoPath != null && System.IO.File.Exists($"{_env.WebRootPath}/src/Events/{found.PhotoPath}"))
                    {
                        System.IO.File.Delete($"{_env.WebRootPath}/src/Events/{found.PhotoPath}");
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

            Event eventEv = new Event(model);
            found.Update(eventEv);
            _context.Events.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { found.Id });
        }
        #endregion
    }
}
