using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.DTOs
{
    public class ReservationDTO
    {
        public Guid Id { get; set; }
        public ICollection<Ticket> Products { get; set; }
        public ReservationStatutes Status { get; set; }
        public DateTime PaymentDeadline { get; set; }
    }
}
