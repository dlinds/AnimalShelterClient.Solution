using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterClient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace AnimalShelterClient.Controllers
{
  public class AnimalsController : Controller
  {
    public IActionResult Index(string species, string gender, string breed, int age, string ageSearchType, int adoptionBudget, string goodWithOtherAnimals, string goodWithChildren)
    {
      var allAnimals = Animal.GetAnimals(species, gender, breed, age, ageSearchType, adoptionBudget, goodWithOtherAnimals, goodWithChildren);
      ViewBag.BreedList = Animal.GetBreeds();
      ViewBag.SpeciesList = Animal.GetSpecies();
      return View(allAnimals);
    }

    public IActionResult Details(int id)
    {
      var thisAnimal = Animal.GetDetails(id);
      return View(thisAnimal);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public IActionResult Create(Animal animal)
    {
      Animal.Post(animal);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var thisAnimal = Animal.GetDetails(id);
      return View(thisAnimal);
    }

    [HttpPost]
    public IActionResult Edit(Animal animal)
    {
      Animal.Put(animal);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      Animal.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
