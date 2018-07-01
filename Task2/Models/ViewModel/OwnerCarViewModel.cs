using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models.CarOwnerDB;

namespace Task2.Models.ViewModel
{
    public class OwnerCarViewModel
    {
        public Owner Owner { get; set; }
        public List<int> CarsIds { get; set; }
    }
}
