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
        public ICollection<Ticket> Products { get; set; }
        public ReservationStatutes Status { get; set; }
        public DateTime PaymentDeadline { get; set; }

        public Reservation(ICollection<Ticket> products, ReservationStatutes status, DateTime paymentDeadline)
        {
            Id = Guid.NewGuid();
            Products = products;
            Status = ReservationStatutes.PaymentPending;
            PaymentDeadline = paymentDeadline;
        }

        public void ChangeStatus(ReservationStatutes status)
        {
            Status = status;
        }
    }
}
