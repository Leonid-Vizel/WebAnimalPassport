using Org.BouncyCastle.Asn1.BC;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAnimalPassport.Models.Data.Vaccination
{
    public abstract class VaccinationBase
    {
        [DisplayName("Тип вакцины")]
        public string Type { get; set; }
        [DisplayName("№ серии")]
        public string? Series { get; set; }
        [DisplayName("ФИО ветеринарного врача")]
        [MaxLength(10000, ErrorMessage = "Максимальная длина - 10000 символов!")]
        public string? DoctorName { get; set; }
        [DisplayName("Дата вакцинации")]
        public DateTime StartDate { get; set; }
        [DisplayName("Действителен до")]
        public DateTime EndDate { get; set; }

        public VaccinationBase() : base() { }

        public VaccinationBase(VaccinationBase model) : this()
        {
            Type  = model.Type;
            Series = model.Series;
            DoctorName = model.DoctorName;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
        }

        public void Update(VaccinationBase model)
        {
            Type = model.Type;
            Series = model.Series;
            DoctorName = model.DoctorName;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
        }
    }
}
