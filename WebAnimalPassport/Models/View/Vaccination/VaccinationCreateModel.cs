using System.ComponentModel;
using WebAnimalPassport.Models.Data.Vaccination;

namespace WebAnimalPassport.Models.View.Vaccination
{
    public class VaccinationCreateModel : VaccinationBase
    {
        [DisplayName("Фото записи вакцинации (необзязательно)")]
        public IFormFile File { get; set; }
        public long AnimalId { get; set; }
    }
}
