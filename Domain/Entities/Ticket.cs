using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket : ArchivableEntity
    {
        public Event Event { get; set; }
        public Guid EventId { get; set; }
        public DateTime Time { get; set; }
        public string Seat { get; set; }
        public decimal Price { get; set; }

        public Ticket(Guid eventId, DateTime time, string seat, decimal price)
        {
            Id = Guid.NewGuid();
            EventId = eventId;
            Time = time;
            Seat = seat;
            Price = price;
        }

        public void ArchiveTickets(ICollection<Ticket> tickets)
        {
            foreach (Ticket ticket in tickets)
            {
                ticket.Archive();
            }
        }
    }
}
