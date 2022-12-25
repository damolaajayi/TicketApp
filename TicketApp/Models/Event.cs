using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketApp.Models
{
    public class Event
    {
        [Column("EventID")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Event Location is a required field.")]

        public string EventLocation { get; set; }
        [Required(ErrorMessage = "Event Time is a required field.")]
        public DateTime EventTime { get; set; }
        [Required(ErrorMessage = "Event Date is a required field.")]
        public string EventDate { get; set; }
        [Required(ErrorMessage = "Event Organizer is a required field.")]
        public string OrganizerName { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        
    }
}
