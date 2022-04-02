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
      return View(allAnimals);
    }

    public IActionResult Details(int id)
    {
      var thisAnimal = Animal.GetDetails(id);
      return View(thisAnimal);
    }
  }
}
