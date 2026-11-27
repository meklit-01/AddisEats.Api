using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Mappers;
using AddisEats.Api.Services.RestaurantService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    [HttpGet]
    public IActionResult GetRestaurants([FromQuery] RestaurantQuery query)
    {
        var result = _restaurantService.GetAllRestaurants(query);

        var response = new PaginatedResultDTO<RestaurantDTO>
        {
            Items = result.Items.Select(r => r.ToDTO()).ToList(),
            TotalCount = result.TotalCount,
            Page = result.Page,
            PageSize = result.PageSize
        };

        return Ok(response);
    }
    [Authorize]
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
    //[HttpGet("active")]
    //public IActionResult GetActive() 
    //{
    //    var restaurants = _restaurantService.GetAllActive();
    //    var restauratsDTOs = restaurants.Select(r =>r.ToDTO()).ToList();
    //    return Ok(restauratsDTOs);
    //}
} 

