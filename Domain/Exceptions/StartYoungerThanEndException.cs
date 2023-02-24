using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class StartYoungerThanEndException : Exception
    {
        public StartYoungerThanEndException() : base("Start date is younger than end date")
        {

        }
    }
}
