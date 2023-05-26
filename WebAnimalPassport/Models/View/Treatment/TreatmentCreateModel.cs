using System.ComponentModel;
using WebAnimalPassport.Models.Data.Treatment;

namespace WebAnimalPassport.Models.View.Treatment
{
    public sealed class TreatmentCreateModel : TreatmentBase
    {
        [DisplayName("Фото (необзязательно)")]
        public IFormFile File { get; set; }
    }
}
