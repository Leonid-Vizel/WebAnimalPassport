using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data
{
    public sealed class CustomUser : IdentityUser
    {
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
        [Required(ErrorMessage = "Укажите город!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string City { get; set; }

        [DisplayName("Регион")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Region { get; set; }

        [DisplayName("Страна")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Country { get; set; }

        [DisplayName("Адрес")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Address { get; set; }

        [DisplayName("Индекс")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string? Index { get; set; }
    }
}
