using System.Threading.Tasks;
using RestSharp;

namespace AnimalShelterClient.Models
{
  class AnimalApiHelper
  {
    public static async Task<string> GetAll(string species, string gender, string breed, int age, string ageSearchType, int adoptionBudget, string goodWithOtherAnimals, string goodWithChildren)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals?species={species}&gender={gender}&breed={breed}&age={age}&ageSearchType={ageSearchType}&adoptionBudget={adoptionBudget}&goodWithOtherAnimals={goodWithOtherAnimals}&goodWithChildren={goodWithChildren}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);

      return response.Content;
    }
    public static async Task<string> GetDetails(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> GetBreeds()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/breeds", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> GetSpecies()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/species", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}
