using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketApp.Models
{
    public class Ticket
    {
        [Column("TicketID")]
        public Guid Id { get; set; }
        [Required]
        public string TicketName { get; set; }
        [Required]
        public string TicketQuantity { get; set; }
        [Required]
        public string TicketType { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        [ForeignKey(nameof(Event))]
        public Guid EventID { get; set; }
        public Event Event { get; set; }
    }
}
