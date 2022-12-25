using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketApp.Models
{
    public class User
    {
        [Column("UsernameID")]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string BillingAddress { get; set; }
        [ForeignKey(nameof(Event))]
        public Guid EventID { get; set; }
        public Event Event { get; set; }
    }
}
