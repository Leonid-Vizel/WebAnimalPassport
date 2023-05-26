using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.User
{
    public abstract class UserBase
    {
        [DisplayName("Почта")]
        [Required(ErrorMessage = "Укажите почту!")]
        [MaxLength(500, ErrorMessage = "Максимальная длина почты: 500 символов!")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты!")]
        public string Login { get; set; }
        [DisplayName("Телефон")]
        [Required(ErrorMessage = "Укажите телефон!")]
        [Phone(ErrorMessage = "Неверный формат телефона!")]
        public string Phone { get; set; }
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Укажите имя!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Укажите фамилию!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Surname { get; set; }
        [DisplayName("Отчество")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Patronymic { get; set; }
        [DisplayName("Город")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? City { get; set; }
        [DisplayName("Страна")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Country { get; set; }

        public UserBase() : base() { }
        public UserBase(UserBase model) : this()
        {
            Login = model.Login;
            Phone = model.Phone;
            Country = model.Country;
            City = model.City;
            Patronymic = model.Patronymic;
            Surname = model.Surname;
            Name = model.Name;
        }
    }
}
