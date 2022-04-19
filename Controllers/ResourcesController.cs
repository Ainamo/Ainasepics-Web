using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AinasepicsApi.Controllers;

[ApiController]
[Route("/api/v2/get-resource")]
public class ResourcesController : ControllerBase
{
    public Random rnd = new Random();

    [HttpGet]    
    [Produces("application/json")]
    public dynamic Get(string name, int? limit = null)
    {
        string ResourcesJson = System.IO.File.ReadAllText("Data/Resources.json");
        var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dictionary<string, dynamic>[]>>>(ResourcesJson);

        if (data == null) return Problem(
            title: "Internal Server Error",
            detail: "Failed to deserialize Resources.json",
            statusCode: 500
        );

        string n = name.ToString();
        Dictionary<string, dynamic>[]? urls = null;

        bool animated = false; 

        /////// Name validation ////////
        if (data["gifs"].ContainsKey(n)) { urls = data["gifs"][n]; animated = true; }
        if (data["images"].ContainsKey(n)) urls = data["images"][n];
        ////////////////////////////////

        if (urls == null) return Problem(
            title: "Bad Request",
            detail: "An invalid 'name' was provided",
            statusCode: 400
        );

        if (limit != null) {
            if (limit > 5 || limit < 1) return Problem(
                title: "Bad Request",
                detail: "'limit' must be between 1 and 5",
                statusCode: 400
            );
            var items = new List<Dictionary<string, dynamic>>();

            for (int k = 0; k < limit; k++) {
                var filteredURLs = urls.Where(
                    item => !items.Any(element => element.Equals(item))
                ).ToArray(); // Filter items that already were added to the array.

                if (filteredURLs.Count() == 0) break; // No more URLs, stop adding items.
                int ri = rnd.Next(0, filteredURLs.Length);
                
                if (filteredURLs[ri].ContainsKey("source")) 
                    filteredURLs[ri].Remove("source"); // Remove because it is not done yet.

                filteredURLs[ri]["animated"] = animated;
                items.Add(filteredURLs[ri]);
            }
            return Ok(items);
        }

        var i = rnd.Next(0, urls.Length);
        if (urls[i].ContainsKey("source")) 
            urls[i].Remove("source"); // Remove because it is not done yet.
        
        urls[i]["animated"] = animated;
        return Ok(urls[i]);
    }
}
