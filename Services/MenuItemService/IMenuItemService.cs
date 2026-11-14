using AddisEats.Api.Models;

namespace AddisEats.Api.Services.MenuItemService;

public interface IMenuItemService
{
	//return type   function
	List<MenuItem> GetAll(string? category);
	MenuItem GetById(int id);
    List<MenuItem> GetByRestaurantId(int restaurantId);
}