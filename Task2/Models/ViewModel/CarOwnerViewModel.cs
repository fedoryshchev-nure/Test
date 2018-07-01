using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models.CarOwnerDB;

namespace Task2.Models.ViewModel
{
    public class CarOwnerViewModel
    {
        public Car Car { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
