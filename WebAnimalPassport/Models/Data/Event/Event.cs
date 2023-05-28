using System.ComponentModel.DataAnnotations;

namespace WebAnimalPassport.Models.Data.Event
{
    public sealed class Event : EventBase
    {
        [Key]
        public long Id { get; set; }
        public CustomUser User { get; set; }
        public string? PhotoPath { get; set; }
        public List<CustomUser> CustomUsers { get; set; }

        public Event() : base() { }
        public Event(EventBase model) : base(model) { }
    }
}
