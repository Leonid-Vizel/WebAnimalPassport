namespace WebAnimalPassport.Models.View.Treatment
{
    public sealed class TreatmentEditModel : TreatmentCreateModel
    {
        public long Id { get; set; }

        public TreatmentEditModel() : base() { }
        public TreatmentEditModel(Data.Treatment.Treatment model) : base(model)
        {
            Id = model.Id;
        }
    }
}
