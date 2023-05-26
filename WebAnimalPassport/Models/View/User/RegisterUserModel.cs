using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebAnimalPassport.Models.Data.User;

namespace WebAnimalPassport.Models.View.User
{
    public sealed class RegisterUserModel : UserBase
    {
        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Укажите пароль!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина пароля: 100 символов!")]
        public string Password { get; set; }
    }
}
