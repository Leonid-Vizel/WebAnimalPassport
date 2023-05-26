using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.View.User
{
    public sealed class ForgotPasswordModel
    {
        [DisplayName("Почта")]
        [Required(ErrorMessage = "Укажите почту!")]
        [MaxLength(500, ErrorMessage = "Максимальная длина почты: 500 символов!")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты")]
        public string Login { get; set; }
    }
}
