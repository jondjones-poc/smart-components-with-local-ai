using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Net9SampleSite.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        /// JSON
        string json = JsonSerializer.Serialize(new { Value = 1 }, JsonSerializerOptions.Web);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IndentCharacter = '\t',
            IndentSize = 2,
        };

        json = JsonSerializer.Serialize(new { Value = 1 }, options);

        /// LinQ
        var myList = new List<int>
        {
            1,
            2,
            3,
            4
        };

        var countByResult = myList.CountBy(x => x == 1);
        var AggregateByResult = myList.AggregateBy(keySelector: x => x == 1, seed: 0, (total, current) => total + current);


        /// UpdatePriority<T
        /// 


        /// Cryptography
        /// For cryptography, .NET 9 adds a new one- shot hash method on the CryptographicOperations type. It also adds new classes that use the KMAC algorithm.


        return View();
    }
}
