using System.ComponentModel;
using WebAnimalPassport.Models.Data.Treatment;

namespace WebAnimalPassport.Models.View.Treatment
{
    public class TreatmentCreateModel : TreatmentBase
    {
        [DisplayName("Фото (необзязательно)")]
        public IFormFile? File { get; set; }
        public long AnimalId { get; set; }

        public TreatmentCreateModel() : base() { }
        public TreatmentCreateModel(TreatmentBase model) : base(model) { }
    }
}
