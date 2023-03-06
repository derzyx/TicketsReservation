using Domain.Enums;

namespace Application.Queries.GetPayment
{
    public record GetPaymentResponse(Guid Id, decimal Amount, PaymentMethodes Methode, PaymentStatutes Status, Guid ReservationId, Guid BuyerId);
}