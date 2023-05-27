using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Digests;
using WebAnimalPassport.Data;
using WebAnimalPassport.Models.Data.Vaccination;
using WebAnimalPassport.Models.View.Vaccination;

namespace WebAnimalPassport.Controllers
{
    public class VaccinationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _appEnvironment;
        public VaccinationController(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
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
            var vac = _context.Vaccinations.Find(Id);
            return View(vac);
        }
        [HttpPost]
        public async Task<IActionResult> Create(VaccinationCreateModel VaccinationData)
        {
            if (VaccinationData.File != null)
            {
                // путь к папке Files
                string path = "/AnimalsPhotos/" + VaccinationData.File.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await VaccinationData.File.CopyToAsync(fileStream);
                }
                Vaccination vac = new Vaccination
                {
                    Doctor = _context.Users.FirstOrDefault(x => $"{x.Name} {x.Surname} {x.Patronymic}" == VaccinationData.DoctorName),
                    Animal = _context.Animals.FirstOrDefault(x => x.Id == VaccinationData.AnimalId),
                    PhotoPath = _appEnvironment.WebRootPath + path,
                    Type = VaccinationData.Type,
                    Series = VaccinationData.Series,
                    DoctorName = VaccinationData.DoctorName,
                    StartDate = VaccinationData.StartDate,
                    EndDate = VaccinationData.EndDate,
                };
                _context.Vaccinations.Add(vac);
                _context.SaveChanges();
            }
            return RedirectToAction("Create");
        }
        public IActionResult Edit(long Id)
        {
            var vac = _context.Vaccinations.Find(Id);
            return View(vac);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VaccinationEditModel VaccinationData)
        {
            var files = HttpContext.Request.Form.Files;
            string path = "/AnimalsPhotos/" + VaccinationData.File.FileName;
            var objFromDb = _context.Vaccinations.AsNoTracking().FirstOrDefault(x => x.Id == VaccinationData.Id);
            if (System.IO.File.Exists(objFromDb.PhotoPath))
                System.IO.File.Delete(objFromDb.PhotoPath);
            if (VaccinationData.File != null)
            {
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await VaccinationData.File.CopyToAsync(fileStream);
                }
                Vaccination vac = new Vaccination
                {
                    //Doctor = _context.Users.FirstOrDefault(x => $"{x.Name} {x.Surname} {x.Patronymic}" == VaccinationData.DoctorName),
                    Animal = _context.Animals.FirstOrDefault(x => x.Id == VaccinationData.AnimalId),
                    PhotoPath = _appEnvironment.WebRootPath + path,
                    Type = VaccinationData.Type,
                    Series = VaccinationData.Series,
                    DoctorName = VaccinationData.DoctorName,
                    StartDate = VaccinationData.StartDate,
                    EndDate = VaccinationData.EndDate,
                };
                _context.Vaccinations.Add(vac);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
