using System.ComponentModel;
using WebAnimalPassport.Models.Data.Examination;

namespace WebAnimalPassport.Models.View.Examination
{
    public class ExaminationCreateModel : ExaminationBase
    {
        public long AnimalId { get; set; }
        [DisplayName("Фото (необзязательно)")]
        public IFormFile? File { get; set; }

        public ExaminationCreateModel() : base() { }
        public ExaminationCreateModel(ExaminationBase model) : base(model) { }
    }
}
