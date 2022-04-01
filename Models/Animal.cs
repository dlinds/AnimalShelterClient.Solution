using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimalShelterClient.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public int AdoptionPrice { get; set; }
    public bool GoodWithOtherAnimals { get; set; }
    public bool GoodWithChildren { get; set; }
    public DateTime DateListed { get; set; }
    public string AnimalPhotoURL { get; set; }

    public static List<Animal> GetAnimals(string species, string gender)
    {
      var apiCallTask = AnimalApiHelper.GetAll(species, gender);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }
    public static Animal GetDetails(int id)
    {
      var apiCallTask = AnimalApiHelper.GetDetails(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }
  }
}