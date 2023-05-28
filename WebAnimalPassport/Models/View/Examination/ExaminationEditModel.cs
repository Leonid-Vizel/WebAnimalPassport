namespace WebAnimalPassport.Models.View.Examination
{
    public sealed class ExaminationEditModel : ExaminationCreateModel
    {
        public long Id { get; set; }

        public ExaminationEditModel() : base() { }
        public ExaminationEditModel(Data.Examination.Examination model) : base(model)
        {
            Id = model.Id;
        }
    }
}
