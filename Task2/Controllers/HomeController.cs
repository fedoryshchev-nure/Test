using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.Models.CarOwnerDB;
using Task2.Models.ViewModel;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        CarOwnerContext db;

        public HomeController(CarOwnerContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cars()
        {
            return View(db.Cars);
        }

        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction("Cars");
        }

        public IActionResult EditCar(int? id)
        {
            if (id != null)
            {
                Car car = db.Cars.FirstOrDefault(x => x.Id == id);
                if (car != null)
                {
                    return View(car);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditCar(Car car)
        {
            db.Cars.Update(car);
            db.SaveChanges();
            return RedirectToAction("Cars");
        }

        public IActionResult DeleteCar(int? id)
        {
            if (id != null)
            {
                Car car = db.Cars.FirstOrDefault(p => p.Id == id);
                if (car != null)
                {
                    db.Cars.Remove(car);
                    db.SaveChanges();
                    return RedirectToAction("Cars");
                }
            }
            return NotFound();
        }

        public IActionResult CarOwner(int? id) // for car all owners
        {
            if (id != null)
            {
                CarOwnerViewModel CarOwner = new CarOwnerViewModel
                {
                    Car = db.Cars.FirstOrDefault(x => x.Id == id)
                };

                if (CarOwner.Car != null)
                {
                    var ownersIds = db.CarOwners
                        .Where(carOwner => carOwner.CarId == id)
                        .Select(y => y.OwnerId)
                        .ToHashSet();
                    CarOwner.Owners = db.Owners
                        .Where(x => ownersIds.Contains(x.Id))
                        .ToList();

                    return View(CarOwner);
                }
            }
            return NotFound();
        }

        public IActionResult Owners()
        {
            return View(db.Owners);
        }

        public IActionResult CreateOwner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOwner(Owner owner)
        {
            db.Owners.Add(owner);
            db.SaveChanges();
            return RedirectToAction("Owners");
        }

        public IActionResult EditOwner(int? id)
        {
            if (id != null)
            {
                OwnerCarIdsViewModel ownerCarViewModel = new OwnerCarIdsViewModel()
                {
                    Owner = db.Owners
                        .Include(x => x.CarOwners)
                        .FirstOrDefault(x => x.Id == id)
                };
                if (ownerCarViewModel.Owner != null)
                {
                    ownerCarViewModel.CarsIds = db.CarOwners
                        .Where(x => x.OwnerId == id)
                        .Select(y => y.CarId)
                        .ToList();

                    return View(ownerCarViewModel);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditOwner(OwnerCarIdsViewModel ownerCarViewModel)
        {
            db.Owners.Update(ownerCarViewModel.Owner);
            db.CarOwners
                .RemoveRange(db.CarOwners
                    .Where(x => x.OwnerId == ownerCarViewModel.Owner.Id)
                );
            db.SaveChanges();
            
            for(int i = 0; i < ownerCarViewModel.CarsIds.Count(); ++i)
            {
                Car car = db.Cars.FirstOrDefault(x => x.Id == ownerCarViewModel.CarsIds[i]);
                if (car != null)
                {
                    db.CarOwners.Add(new CarOwner()
                    {
                        Owner = ownerCarViewModel.Owner,
                        Car = car
                    });
                }
            }

            db.SaveChanges();
            return RedirectToAction("Owners");
        }

        public IActionResult DeleteOwner(int? id)
        {
            if (id != null)
            {
                Owner owner = db.Owners.FirstOrDefault(p => p.Id == id);
                if (owner != null)
                {
                    db.Owners.Remove(owner);
                    db.SaveChanges();
                    return RedirectToAction("Owners");
                }
            }
            return NotFound();
        }

        public IActionResult OwnerCar(int? id) // for owners all cars
        {
            if (id != null)
            {
                OwnerCarViewModel OwnerCarViewModel = new OwnerCarViewModel
                {
                    Owner = db.Owners.FirstOrDefault(x => x.Id == id)
                };

                if (OwnerCarViewModel.Owner != null)
                {
                    var carsIds = db.CarOwners
                        .Where(ownerCar => ownerCar.OwnerId == id)
                        .Select(y => y.CarId)
                        .ToHashSet();
                    OwnerCarViewModel.Cars = db.Cars
                        .Where(x => carsIds.Contains(x.Id))
                        .ToList();

                    return View(OwnerCarViewModel);
                }
            }
            return NotFound();
        }
    }
}
