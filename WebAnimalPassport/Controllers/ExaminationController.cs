using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Data.Examination;
using WebAnimalPassport.Models.View.Examination;

namespace WebAnimalPassport.Controllers
{
    public sealed class ExaminationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public ExaminationController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _context = db;
            _env = env;
        }

        #region Create
        public async Task<IActionResult> Create(long id)
        {
            if (!await _context.Animals.AnyAsync(x => x.Id == id))
            {
                return NotFound();
            }
            ExaminationCreateModel model = new ExaminationCreateModel()
            {
                AnimalId = id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExaminationCreateModel model)
        {
            Animal? found = await _context.Animals.FindAsync(model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            Examination examination = new Examination(model);
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Examinations/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Examinations/{guid}{extension}";
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
                examination.PhotoPath = $"{guid}{extension}";
            }
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            examination.Animal = found;
            await _context.Examinations.AddAsync(examination);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Animal", new { found.Id });
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(long id)
        {
            Examination? found = await _context.Examinations.FindAsync(id);
            if (found == null)
            {
                return NotFound();
            }
            ExaminationEditModel model = new ExaminationEditModel(found);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExaminationEditModel model)
        {
            Examination? found = await _context.Examinations
                .Include(x => x.Doctor)
                .Include(x => x.Animal)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (found == null)
            {
                return NotFound();
            }
            Animal? animal = await _context.Animals.FindAsync(found.Animal.Id);
            if (animal == null)
            {
                return NotFound();
            }
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Examinations/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Examinations/{guid}{extension}";
                }
                try
                {
                    using (FileStream createStream = new FileStream(completePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(createStream);
                    }
                    if (found.PhotoPath != null && System.IO.File.Exists($"{_env.WebRootPath}/src/Examinations/{found.PhotoPath}"))
                    {
                        System.IO.File.Delete($"{_env.WebRootPath}/src/Examinations/{found.PhotoPath}");
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
            Examination examination = new Examination(model);
            found.Update(examination);
            _context.Examinations.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Animal", new { animal.Id });
        }
        #endregion
    }
}
