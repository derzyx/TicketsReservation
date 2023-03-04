using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException() : base("Can't find reservation with this ID")
        {

        }
    }
}
