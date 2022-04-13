using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AinasepicsApi.Controllers;

[ApiController]
[Route("/api/v2/Resources.json")]
public class ResourcesController : ControllerBase
{
    public Random rnd = new Random();

    [HttpGet]    
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

        string[] gifNames = data["gifs"].Keys.ToArray();
        string[] imageNames = data["images"].Keys.ToArray();

        // Name validation
        if (Array.Exists(gifNames, gn => gn == n)) { urls = data["gifs"][n]; animated = true; }
        else if (Array.Exists(imageNames, _in => _in == n)) urls = data["images"][n];

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
                items.Add(filteredURLs[ri]);
            }
            return JsonSerializer.Serialize(items);
        }

        var i = rnd.Next(0, urls.Length);
        urls[i]["animated"] = animated;
        return JsonSerializer.Serialize(urls[i]);
    }
}
