using MenuExplorer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using static MenuExplorer.Models.MenuItem;

namespace MenuExplorer.Controllers
{
    public class MenuController : Controller
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public MenuController(JsonSerializerOptions jsonSerializerOptions)
        {
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        public IActionResult Index(string category)
        {
            var menuItemsJson = System.IO.File.ReadAllText("Data/menuItems.json");

            List<MenuItem> menuItems = JsonSerializer.Deserialize<List<MenuItem>>(menuItemsJson, _jsonSerializerOptions);

            if (!string.IsNullOrEmpty(category))
            {
                var menuCategory = Enum.Parse<MenuCategory>(category, true);
                menuItems = menuItems.Where(items => items.Category == menuCategory).ToList();
            }

            return View(menuItems);
        }

        public IActionResult ItemDetails(int Id)
        {
            var menuItemsJson = System.IO.File.ReadAllText("Data/menuItems.json");

            List<MenuItem> menuItems = JsonSerializer.Deserialize<List<MenuItem>>(menuItemsJson, _jsonSerializerOptions);

            var menuItem = menuItems.FirstOrDefault(x => x.Id == Id);

            return View(menuItem);
        }



      
    }
}
