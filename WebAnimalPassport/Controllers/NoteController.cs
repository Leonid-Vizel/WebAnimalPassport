using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Data.Note;
using WebAnimalPassport.Models.Data.Vaccination;
using WebAnimalPassport.Models.View.Treatment;
using WebAnimalPassport.Models.View.Vaccination;

namespace WebAnimalPassport.Controllers
{
    public class NoteController : Controller

    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _env;
        public NoteController(ApplicationDbContext db, IWebHostEnvironment env)
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
            Note model = new Note()
            {
                Animal = _context.Animals.Find(id),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Note model)
        {
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            Animal? found = await _context.Animals.FindAsync(model.Animal.Id);
            if (found == null)
            {
                return NotFound();
            }
            Note note = new Note(model);
           
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Animal", new { found.Id });
        }
        #endregion


        #region Edit
        public async Task<IActionResult> Edit(long id)
        {
            Note? found = await _context.Notes.FindAsync(id);
            if (found == null)
            {
                return NotFound();
            }
            Note model = new Note(found);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Note model)
        {
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            Note? found = await _context.Notes
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
            Note note = new Note(model);
            found.Update(note);
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Animal", new { animal.Id });
        }
        #endregion
    }
}
