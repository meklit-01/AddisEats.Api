using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Mappers;
using AddisEats.Api.Services.RestaurantService;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Services.MenuItemService;
namespace AddisEats.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]

public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMenuItemService _menuItemService;

    public RestaurantController(
        IRestaurantService restaurantService,
        IMenuItemService menuItemService)
    {
        _restaurantService = restaurantService;
        _menuItemService = menuItemService;
    }
    [HttpGet("{id}")]

    public IActionResult GetRestaurat(int id)
    {
        var restaurant = _restaurantService.GetRestaurantById(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return Ok(restaurant);

    }
    [HttpGet()]
    public IActionResult GetRestaurat([FromQuery] string? address, [FromQuery] int page = 1, [FromQuery] int pageSize = 3)
    {
        var restaurants = _restaurantService.GetAllRestaurants(address, page, pageSize);
        var restaurantDTOs = restaurants.Select(r => r.ToDTO()).ToList();
        return Ok(restaurantDTOs);

    }
    [HttpGet("{id}/menu")]
    public IActionResult GetRestaurantMenu(int id)
    {
        // Check whether the restaurant exists
        var restaurant = _restaurantService.GetRestaurantById(id);

        if (restaurant == null)
        {
            return NotFound("Restaurant not found");
        }

        // Get menu items belonging to this restaurant
        var menuItems = _menuItemService.GetByRestaurantId(id);

        return Ok(menuItems);
    }
}

