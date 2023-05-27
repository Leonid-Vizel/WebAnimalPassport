using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data.Treatment;
using WebAnimalPassport.Models.View.Treatment;

namespace WebAnimalPassport.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _appEnvironment;
        public TreatmentController(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
        {
            _context = db;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Show(long Id)
        {
            var vac = _context.Treatments.Find(Id);
            return View(vac);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TreatmentCreateModel TreatmentData)
        {
            if (TreatmentData.File != null)
            {
                // путь к папке Files
                string path = "/TreatmentPhotos/" + Guid.NewGuid().ToString(); ;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await TreatmentData.File.CopyToAsync(fileStream);
                }
                Treatment treatment = new Treatment
                {
                    Animal = _context.Animals.Find(TreatmentData.AnimalId),
                    PhotoPath = _appEnvironment.WebRootPath + path,
                    DateTime = TreatmentData.DateTime,
                    TreatmentType = TreatmentData.TreatmentType,
                    Drug = TreatmentData.Drug,
                    Doze = TreatmentData.Doze,
                    DoctorName = TreatmentData.DoctorName,
                    Doctor = _context.Users.FirstOrDefault(x => $"{x.Name} {x.Surname} {x.Patronymic}" == TreatmentData.DoctorName),
                };
                _context.Treatments.Add(treatment);
                _context.SaveChanges();
            }
            return RedirectToAction("Create");
        }
        public IActionResult Edit(long Id)
        {
            var vac = _context.Treatments.Find(Id);
            return View(vac);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TreatmentEditModel TreatmentData)
        {
            var files = HttpContext.Request.Form.Files;
            string path = "/TreatmentPhotos/" + Guid.NewGuid().ToString(); ;
            var objFromDb = _context.Treatments.AsNoTracking().FirstOrDefault(x => x.Id == TreatmentData.Id);
            if (System.IO.File.Exists(objFromDb.PhotoPath))
                System.IO.File.Delete(objFromDb.PhotoPath);
            if (TreatmentData.File != null)
            {
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await TreatmentData.File.CopyToAsync(fileStream);
                }
                Treatment treatment = new Treatment
                {
                    Animal = _context.Animals.Find(TreatmentData.AnimalId),
                    PhotoPath = _appEnvironment.WebRootPath + path,
                    DateTime = TreatmentData.DateTime,
                    TreatmentType = TreatmentData.TreatmentType,
                    Drug = TreatmentData.Drug,
                    Doze = TreatmentData.Doze,
                    DoctorName = TreatmentData.DoctorName,
                    Doctor = _context.Users.FirstOrDefault(x => $"{x.Name} {x.Surname} {x.Patronymic}" == TreatmentData.DoctorName),
                };
                _context.Treatments.Add(treatment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
