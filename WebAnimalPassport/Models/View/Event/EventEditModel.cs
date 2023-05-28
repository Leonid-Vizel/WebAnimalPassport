namespace WebAnimalPassport.Models.View.Event
{
    public class EventEditModel : EventCreateModel
    {
        public long Id { get; set; }

        public EventEditModel() : base() { }
        public EventEditModel(Data.Event.Event model) : base(model)
        {
            Id = model.Id;
        }
    }
}
