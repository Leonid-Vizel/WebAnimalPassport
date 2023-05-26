using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAnimalPassport.Models.View.User;

namespace WebAnimalPassport.Models.Data.User
{
    public sealed class User : UserBase
    {
        [Key]
        public long Id { get; set; }
        [DisplayName("Дата регистрации")]
        public DateTime RegitserDate { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public Guid? Verificator { get; set; }

        public User() : base() { }
        public User(UserBase model) : base(model) { }
        public User(EditUserModel model) : base(model)
        {
            Id = model.Id;
        }
        public User(RegisterUserModel model) : base(model)
        {
            RegitserDate = DateTime.Now;
            Verificator = Guid.NewGuid();
        }
    }
}
