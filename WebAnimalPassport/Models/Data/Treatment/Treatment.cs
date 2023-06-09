﻿using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Treatment
{
    public sealed class Treatment : TreatmentBase
    {
        [Key]
        public long Id { get; set; }
        public Animal.Animal Animal { get; set; }
        public CustomUser? Doctor { get; set; }
        public string? PhotoPath { get; set; }
        public bool Valid { get; set; }

        public Treatment() : base() { }
        public Treatment(TreatmentBase model) : base(model) { }
    }
}
