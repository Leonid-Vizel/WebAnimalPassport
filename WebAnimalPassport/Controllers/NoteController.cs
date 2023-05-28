using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Data.Note;
using WebAnimalPassport.Models.View.Note;

namespace WebAnimalPassport.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NoteController(ApplicationDbContext db)
        {
            _context = db;
        }

        #region Create
        public async Task<IActionResult> Create(long id)
        {
            if (!await _context.Animals.AnyAsync(x => x.Id == id))
            {
                return NotFound();
            }
            NoteCreateModel model = new NoteCreateModel()
            {
                AnimalId = id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoteCreateModel model)
        {
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            Animal? found = await _context.Animals.FindAsync(model.AnimalId);
            if (found == null)
            {
                return NotFound();
            }
            Note note = new Note(model);
            note.Animal = found;
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
            NoteEditModel model = new NoteEditModel(found);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NoteEditModel model)
        {
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }
            Note? found = await _context.Notes
                .Include(x=> x.Animal)
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
            found.Update(model);
            _context.Notes.Update(found);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Animal", new { animal.Id });
        }
        #endregion
    }
}
