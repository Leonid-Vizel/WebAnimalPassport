using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Examination
{
    public abstract class ExaminationBase
    {
        [DisplayName("Декларация")]
        [Required(ErrorMessage = "Укажите декларацию!")]
        public string Declaration { get; set; }
        [DisplayName("Дата")]
        [Required(ErrorMessage = "Укажите дату!")]
        public DateTime Date { get; set; }
        [DisplayName("ФИО ветеринара")]
        public string? DoctorName { get; set; }

        public ExaminationBase() : base() { }
        public ExaminationBase(ExaminationBase model) : this()
        {
            Declaration = model.Declaration;
            Date = model.Date;
            DoctorName = model.DoctorName;
        }

        public void Update(ExaminationBase model)
        {
            Declaration = model.Declaration;
            Date = model.Date;
            DoctorName = model.DoctorName;
        }
    }
}
