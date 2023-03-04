using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException() : base("Can't find event with this ID")
        {

        }
    }
}
