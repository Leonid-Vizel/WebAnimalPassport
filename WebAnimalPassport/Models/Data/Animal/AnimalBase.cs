using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAnimalPassport.Models.Enums;

namespace WebAnimalPassport.Models.Data.Animal
{
    public abstract class AnimalBase
    {
        [DisplayName("Кличка")]
        [Required(ErrorMessage = "Укажите кличку!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Name { get; set; }
        [DisplayName("Вид")]
        [Required(ErrorMessage = "Укажите вид!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Species { get; set; }
        [DisplayName("Порода")]
        [Required(ErrorMessage = "Укажите породу!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Breed { get; set; }
        [DisplayName("Пол")]
        [Required(ErrorMessage = "Укажите пол!")]
        [Range(0,2, ErrorMessage = "Укажите пол!")]
        public Sex Sex { get; set; }
        [DisplayName("Шерсть")]
        [Required(ErrorMessage = "Укажите описание шерсти (например: окрас)!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Hair { get; set; }
        [DisplayName("Номер микрочипа")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? ChipNumber { get; set; }
        [DisplayName("Дата чипирования")]
        public DateTime? ChipDate { get; set; }
        [DisplayName("Расположение микрочипа")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? ChipLocation { get; set; }
        [DisplayName("Клеймо")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? TattoNumber { get; set; }
        [DisplayName("Дата клеймления")]
        public DateTime? TattoDate { get; set; }

        public AnimalBase() : base() { }
        public AnimalBase(AnimalBase model) : this()
        {
            Name = model.Name;
            Species = model.Species;
            Breed = model.Breed;
            Sex = model.Sex;
            Hair = model.Hair;
            ChipNumber = model.ChipNumber;
            ChipDate = model.ChipDate;
            ChipLocation = model.ChipLocation;
            TattoNumber = model.TattoNumber;
            TattoDate = model.TattoDate;
        }

        public void Update(AnimalBase model)
        {
            Name = model.Name;
            Species = model.Species;
            Breed = model.Breed;
            Sex = model.Sex;
            Hair = model.Hair;
            ChipNumber = model.ChipNumber;
            ChipDate = model.ChipDate;
            ChipLocation = model.ChipLocation;
            TattoNumber = model.TattoNumber;
            TattoDate = model.TattoDate;
        }
    }
}
