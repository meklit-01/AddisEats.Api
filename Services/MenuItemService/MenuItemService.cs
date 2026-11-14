
using AddisEats.Api.Models;
using AddisEats.Api.Data;

namespace AddisEats.Api.Services.MenuItemService;

public class MenuItemService : IMenuItemService
{
    private readonly List<MenuItem> _menuItems = SeedData.MenuItems;

    public List<MenuItem> GetAll(string? category)
    {
        return _menuItems
            .Where(x => category == null || x.Category == category)
            .ToList();
    }

    public MenuItem? GetById(int id)
    {
        return _menuItems.FirstOrDefault(m => m.Id == id);
    }

    public List<MenuItem> GetByRestaurantId(int restaurantId)
    {
        return _menuItems
            .Where(m => m.RestaurantId == restaurantId)
            .ToList();
    }
}
