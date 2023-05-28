using System.ComponentModel;
using WebAnimalPassport.Models.Data.Animal;
using WebAnimalPassport.Models.Data.Event;

namespace WebAnimalPassport.Models.View.Event
{
    public class EventCreateModel : EventBase
    {
        [DisplayName("Банер мероприятия")]
        public IFormFile? File { get; set; }

        public EventCreateModel() : base() { }
        public EventCreateModel(EventBase model) : base(model) { }
    }
}
