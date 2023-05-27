using System.ComponentModel;
using WebAnimalPassport.Models.Data.Animal;

namespace WebAnimalPassport.Models.View.Animal
{
    public class AnimalCreateModel : AnimalBase
    {
        [DisplayName("Фото питомца (необязательно)")]
        public IFormFile? File { get; set; }

        public AnimalCreateModel() : base() { }
        public AnimalCreateModel(AnimalBase model) : base(model) { }
    }
}
