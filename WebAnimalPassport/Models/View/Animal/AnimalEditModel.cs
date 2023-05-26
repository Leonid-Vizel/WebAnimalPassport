namespace WebAnimalPassport.Models.View.Animal
{
    public sealed class AnimalEditModel : AnimalCreateModel
    {
        public long Id { get; set; }

        public AnimalEditModel() : base() { }
        public AnimalEditModel(Data.Animal.Animal model) : base(model)
        {
            Id = model.Id;
        }
    }
}
