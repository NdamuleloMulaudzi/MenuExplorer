using MenuExplorer.Models;
using System.Text.Json;

namespace MenuExplorer.Services
{
    public class MenuService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public MenuService(JsonSerializerOptions jsonSerializerOptions)
        {
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        public List<MenuItem> GetAll()
        {
            var menuItemsJson = System.IO.File.ReadAllText("Data/menuItems.json");

            if (string.IsNullOrEmpty(menuItemsJson))
            {
                return new List<MenuItem>();
            }

            List<MenuItem> menuItems = JsonSerializer.Deserialize<List<MenuItem>>(menuItemsJson, _jsonSerializerOptions);

            return menuItems;
        }

        public MenuItem GetById(int id)
        {
            var menuItems = GetAll();
            
            return menuItems.FirstOrDefault(menuItem => menuItem.Id == id);
        }
    }
}
