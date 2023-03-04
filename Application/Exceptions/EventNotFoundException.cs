using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException() : base("Can't find event with this ID")
        {

        }
    }
}
