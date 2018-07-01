using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models.CarOwnerDB
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public bool IsPassengerCar { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Year { get; set; }

        public List<CarOwner> CarOwners { get; set; }
    }
}
