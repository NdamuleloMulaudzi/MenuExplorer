using MenuExplorer.Models;
using MenuExplorer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using static MenuExplorer.Models.MenuItem;

namespace MenuExplorer.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuService _menuService;

        public MenuController(MenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index(string category)
        {
            var menuItems = _menuService.GetAll();
            if (!string.IsNullOrEmpty(category))
            {
                menuItems = menuItems.Where(item => item.Category.ToString().Equals(category)).ToList();
            }
            return View(menuItems);
        }

        public IActionResult ItemDetails(int Id)
        {
            var menuItem = _menuService.GetById(Id);
            return View(menuItem);
        }
    }
}
