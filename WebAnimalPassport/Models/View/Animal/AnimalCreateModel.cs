using System.ComponentModel;
using WebAnimalPassport.Models.Data.Animal;

namespace WebAnimalPassport.Models.View.Animal
{
    public class AnimalCreateModel : AnimalBase
    {
        [DisplayName("Фото питомца")]
        public IFormFile File { get; set; }
    }
}
