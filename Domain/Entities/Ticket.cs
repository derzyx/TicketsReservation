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
        public DateTime Time { get; set; }
        public string Seat { get; set; }
        public decimal Price { get; set; }
    }
}
