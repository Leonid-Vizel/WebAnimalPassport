using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using WebAnimalPassport.Models.Data.User;

namespace WebAnimalPassport.Models.Data.Vaccination
{
    public abstract class VaccinationBase
    {
        [DisplayName("Тип вакцины")]
        public string Type { get; set; }
        [DisplayName("№ серии")]
        public string? Series { get; set; }
        public string? DoctorName { get; set; }
        [ForeignKey("User")]
        public long? DoctorId { get; set; }
        public User.User? Doctor { get; set; }
    }
}
