using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation : ArchivableEntity
    {
        public IEnumerator<Ticket> Products { get; set; }
        public ReservationStatutes Status { get; set; }
        public DateTime PaymentDeadline { get; set; }
    }
}
