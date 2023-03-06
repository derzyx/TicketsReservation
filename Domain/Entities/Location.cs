using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public struct Location
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ObjectType { get; set; }
        public int ObjectCapacity { get; set; }

        public Location(string country, string city, string street, string objectType, int objectCapacity)
        {
            Country = country;
            City = city;
            Street = street;
            ObjectType = objectType;
            ObjectCapacity = objectCapacity;
        }
    }
}
