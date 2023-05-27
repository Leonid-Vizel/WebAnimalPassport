using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Data.Treatment;
using WebAnimalPassport.Models.View.Treatment;

namespace WebAnimalPassport.Controllers
{
    public sealed class TreatmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public TreatmentController(ApplicationDbContext db, IWebHostEnvironment env)
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
            TreatmentCreateModel model = new TreatmentCreateModel()
            {
                AnimalId = id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TreatmentCreateModel model)
        {
            Animal? found = await _context.Animals.FindAsync(model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            Treatment treatment = new Treatment(model);
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Treatments/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Treatments/{guid}{extension}";
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
                treatment.PhotoPath = $"{guid}{extension}";
            }
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            treatment.Animal = found;
            await _context.Treatments.AddAsync(treatment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Animal", new { found.Id });
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(long id)
        {
            Treatment? found = await _context.Treatments.FindAsync(id);
            if (found == null)
            {
                return NotFound();
            }
            TreatmentEditModel model = new TreatmentEditModel(found);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TreatmentEditModel model)
        {
            Treatment? found = await _context.Treatments
                .Include(x => x.Doctor)
                .Include(x => x.Animal)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            if (found == null)
            {
                return NotFound();
            }
            Treatment? animal = await _context.Treatments.FindAsync(found.Animal.Id);
            if (animal == null)
            {
                return NotFound();
            }
            if (model.File != null)
            {
                Guid guid = Guid.NewGuid();
                string extension = Path.GetExtension(model.File.FileName);
                string completePath = $"{_env.WebRootPath}/src/Treatments/{guid}{extension}";
                while (System.IO.File.Exists(completePath))
                {
                    guid = Guid.NewGuid();
                    completePath = $"{_env.WebRootPath}/src/Treatments/{guid}{extension}";
                }
                try
                {
                    using (FileStream createStream = new FileStream(completePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(createStream);
                    }
                    if (found.PhotoPath != null && System.IO.File.Exists($"{_env.WebRootPath}/src/Treatments/{found.PhotoPath}"))
                    {
                        System.IO.File.Delete($"{_env.WebRootPath}/src/Treatments/{found.PhotoPath}");
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
            Treatment treatment = new Treatment(model);
            found.Update(treatment);
            _context.Treatments.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Animal", new { animal.Id });
        }
        #endregion
    }
}
