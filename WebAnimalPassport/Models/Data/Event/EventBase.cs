using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Event
{
    public abstract class EventBase
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Укажите название мероприятия!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [Required(ErrorMessage = "Напишите краткое описание мероприятия!")]
        [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
        public string Description { get; set; }

        [DisplayName("Дата начала")]
        [Required(ErrorMessage = "Укажите дату!")]
        public DateTime DateStart { get; set; }

        [DisplayName("Дата конца")]
        [Required(ErrorMessage = "Укажите дату!")]
        public DateTime DateFinish { get; set; }

        public EventBase() : base() { }
        public EventBase(EventBase model) : this()
        {
            Name = model.Name;
            Description = model.Description;
            DateStart = model.DateStart;
            DateFinish = model.DateFinish;
        }

        public void Update(EventBase model)
        {
            Name = model.Name;
            Description = model.Description;
            DateStart = model.DateStart;
            DateFinish = model.DateFinish;
        }
    }
}
