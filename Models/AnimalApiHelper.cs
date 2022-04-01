using System.Threading.Tasks;
using RestSharp;

namespace AnimalShelterClient.Models
{
  class AnimalApiHelper
  {
    public static async Task<string> GetAll(string species, string gender)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals?species={species}&gender={gender}", Method.GET);
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
  }
}
