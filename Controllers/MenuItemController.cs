using AddisEats.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddisEates.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class MenuItemController : ControllerBase
{
    List<MenuItem> menuItems = new List<MenuItem>
    {
        new MenuItem { Id = 1, Name = "Doro Wet", Category = "Traditional", Price = 250 },
        new MenuItem { Id = 2, Name = "Kitfo", Category = "Traditional", Price = 350 },
        new MenuItem { Id = 3, Name = "Shiro", Category = "Traditional", Price = 150 },
        new MenuItem { Id = 4, Name = "Tibs", Category = "Traditional", Price = 300 },
        new MenuItem { Id = 5, Name = "Firfir", Category = "Breakfast", Price = 120},
        new MenuItem { Id = 6, Name = "Chechebsa", Category = "Breakfast", Price = 130},
        new MenuItem { Id = 7, Name = "Pasta", Category = "Main Course", Price = 200},
        new MenuItem { Id = 8, Name = "Pizza", Category = "Fast Food", Price = 450 },
        new MenuItem { Id = 9, Name = "Cheeseburger", Category = "Fast Food", Price = 280},
        new MenuItem { Id = 10, Name = "French Fries", Category = "Side Dish", Price = 100},
        new MenuItem { Id = 11, Name = "Grilled Chicken", Category = "Main Course", Price = 320},
        new MenuItem { Id = 12, Name = "Caesar Salad", Category = "Salad", Price = 180},
        new MenuItem { Id = 13, Name = "Fresh Juice", Category = "Drinks", Price = 90 },
        new MenuItem { Id = 14, Name = "Coffee", Category = "Drinks", Price = 40 },
        new MenuItem { Id = 15, Name = "Fruit Salad", Category = "Dessert", Price = 150}
    };

    [HttpGet]

    public IActionResult GetAll()
    {
        return Ok(menuItems);
    }
}