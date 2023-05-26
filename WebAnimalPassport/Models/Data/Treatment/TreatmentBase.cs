﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Treatment
{
    public abstract class TreatmentBase
    {
        [DisplayName("Дата и время")]
        [Required(ErrorMessage = "Укажите дату и время!")]
        public DateTime DateTime { get; set; }
    }
}