using Application.Commands.Payments.NewPayment;
using Application.Commands.Payments.UpdatePayment;
using Application.Queries.GetPayment;
using Application.Queries.GetReservation;
using Application.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromRoute] Guid reservationId, [FromBody] Guid userId, [FromQuery] PaymentMethodes paymentMethode)
        {
            var reservationResp = await mediator.Send(new GetReservationQuery(reservationId));

            if (reservationResp.status == ReservationStatutes.PaymentPending)
            {
                var payment = new NewPaymentCommand(
                paymentMethode,
                reservationId,
                new Reservation(
                    reservationResp.products,
                    reservationResp.status,
                    reservationResp.paymentDeadline
                ),
                userId);

                var response = await mediator.Send(payment);
                return Ok(response);
            }
            else
            {
                //Can't make new payment 
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromBody] Guid paymentId, PaymentStatutes status)
        {
            var payment = await mediator.Send(new GetPaymentQuery(paymentId));

            await mediator.Send(new UpdatePaymentCommand(payment.Id, status));

            return Ok(payment);
        }
    }
}
