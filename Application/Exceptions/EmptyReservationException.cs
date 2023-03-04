using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EmptyReservationException : Exception
    {
        public EmptyReservationException() : base("Reservation has no tickets")
        {

        }
    }
}
