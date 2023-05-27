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
        [DisplayName("Порода")]
        [Required(ErrorMessage = "Укажите породу!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Breed { get; set; }
        [DisplayName("Пол")]
        [Required(ErrorMessage = "Укажите пол!")]
        [Range(0,2, ErrorMessage = "Укажите пол!")]
        public Sex Sex { get; set; }
        [DisplayName("Вид")]
        [Required(ErrorMessage = "Укажите вид!")]
        public AnimalType Type { get; set; }
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
        [DisplayName("Дата рождения")]
        [Required(ErrorMessage = "Укажите дату рождения!")]
        public DateTime BirthDate { get; set; }
        public string? LostLocation { get; set; }

        public AnimalBase() : base() { }
        public AnimalBase(AnimalBase model) : this()
        {
            Name = model.Name;
            Type = model.Type;
            BirthDate = model.BirthDate;
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
            BirthDate = model.BirthDate;
            Type = model.Type;
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
