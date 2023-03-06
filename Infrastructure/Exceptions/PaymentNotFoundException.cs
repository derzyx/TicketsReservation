using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class PaymentNotFoundException : Exception
    {
        public PaymentNotFoundException() : base("Can't find payment with this Id")
        {

        }
    }
}
