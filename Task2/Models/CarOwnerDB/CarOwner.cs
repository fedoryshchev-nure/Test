using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models.CarOwnerDB
{
    public class CarOwner
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
