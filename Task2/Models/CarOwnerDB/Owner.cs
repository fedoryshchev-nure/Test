using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models.CarOwnerDB
{
    public class Owner
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int BirthYear { get; set; }
        [Required]
        public int DrivingExperienceDays { get; set; }

        public List<CarOwner> CarOwners { get; set; }
    }
}
