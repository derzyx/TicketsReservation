using Domain.Common;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event : ArchivableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location Location { get; set; }
        public int AllTickets { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public Event(string name, string description, DateTime startDate, DateTime endDate, Location location, int allTickets)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            ValidateDate(startDate, endDate);
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            AllTickets = allTickets;
        }

        public void Update(string? name, string? description, DateTime? startDate, DateTime? endDate, Location? location, int? allTickets)
        {
            Name = (name == null) ? this.Name : name;
            Description = (description == null) ? this.Description : description;

            var start = (startDate == null) ? this.StartDate : (DateTime)startDate;
            var end = (endDate == null) ? this.EndDate : (DateTime)endDate;
            ValidateDate(start, end);
            StartDate = start;
            EndDate = end;

            Location = (location == null) ? this.Location : (Location)location;
            AllTickets = (allTickets == null) ? this.AllTickets : (int)allTickets;
        }

        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public void AddTickets(ICollection<Ticket> tickets)
        {
            Tickets.Concat(tickets);
        }

        private static void ValidateDate(DateTime start, DateTime end)
        {
            if (start > end) throw new StartYoungerThanEndException();
        }
    }
}
