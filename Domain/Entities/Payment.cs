using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : ArchivableEntity
    {
        public Reservation Reservation { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethodes Method { get; set; }
        public PaymentStatutes Status { get; set; }
        public User Buyer { get; set; }
    }
}
