using AddisEats.Api.Models;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Services.MenuItemService;

namespace AddisEates.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class MenuItemController : ControllerBase
{
    //This declares a variable to hold the service.
    //It means the actual implementation of IMenuItemService is assigned to the _menuItemService variable through Dependency Injection.
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }
   
    [HttpGet]

    public IActionResult GetAll()
    {
        var result = _menuItemService.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        var result = _menuItemService.GetById(id);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    

}