﻿using AdoptionMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoptionMVC.Controllers
{
    public class AdoptionController : Controller
    {
        AdoptionDbContext dbContext = new AdoptionDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            List<Animal> result = dbContext.Animals.ToList();
            return View(result);
        }

        public IActionResult Breed()
        {
            List<Animal> result=dbContext.Animals.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Result()
        {
            List<Animal> result = dbContext.Animals.ToList();
            return View(result);
        }
        [HttpPost]
        public IActionResult Result(string breed)
        {
            List<Animal> result = dbContext.Animals.Where(b => b.Breed == breed).ToList();
            return View(result);
        }

        public IActionResult Adopt(Animal result)
        {
            return View(result);
        }

        public IActionResult RemoveAnimal(int id)
        {
            Animal Animal = dbContext.Animals.FirstOrDefault(a => a.Id == id);
            dbContext.Animals.Remove(Animal);
            dbContext.SaveChanges();
            return RedirectToAction("Confirmation", new { msg = $"{Animal.Name} has been adopted" });
        }

        public IActionResult AddAnimal(List<Animal> result)
        {
            Animal Animal;
            return View();
        }
        public IActionResult Confirmation(string msg)
        {
            ViewData["msg"] = msg;
            return View();
        }

    }
}
