using AddisEats.Api.Models;
using AddisEats.Api.Data;

namespace AddisEats.Api.Services.RestaurantService;

public class RestaurantService : IRestaurantService
{
    private readonly List<Restaurant> allRestaurants = SeedData.restaurants;

    public Restaurant? GetRestaurantById(int id)
    {
        return allRestaurants.FirstOrDefault(x => x.Id == id);
    }

    public List<Restaurant> GetAllRestaurants(string? address, int page, int pageSize)
    {
        var restaurants = allRestaurants
            .Where(r => address == null || r.Address == address)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return restaurants;
    }
}