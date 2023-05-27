namespace WebAnimalPassport.Models.View.Vaccination
{
    public sealed class VaccinationEditModel : VaccinationCreateModel
    {
        public long Id { get; set; }

        public VaccinationEditModel() : base() { }
        public VaccinationEditModel(Data.Vaccination.Vaccination model) : base(model)
        {
            Id = model.Id;
        }
    }
}
