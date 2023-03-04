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
        public decimal Amount { get; set; }
        public PaymentMethodes Method { get; set; }
        public PaymentStatutes Status { get; set; }
        public Reservation Reservation { get; set; }
        public Guid ReservationId { get; set; }
        public User Buyer { get; set; }
        public Guid BuyerId { get; set; }

        public Payment(decimal amount, PaymentMethodes methode, Guid reservationId, Guid buyerId)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Method = methode;
            ReservationId = reservationId;
            BuyerId = buyerId;
        }

        public void CheckDeadline(Reservation reservation)
        {
            if(reservation.PaymentDeadline < DateTime.Now)
            {
                ChangeStatus(PaymentStatutes.Failed);
            }
        }

        public void ChangeStatus(PaymentStatutes status)
        {
            Status = status;
        }
    }
}
