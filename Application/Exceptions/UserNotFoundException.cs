﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("Can't find user with this ID")
        {

        }
    }
}
