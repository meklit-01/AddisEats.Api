using AddisEats.Api.Models;
using AddisEats.Api.Data;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.RestaurantService;

public class RestaurantService : IRestaurantService
{
    private readonly List<Restaurant> allRestaurants = SeedData.restaurants;

    public Restaurant? GetRestaurantById(int id)
    {
        return allRestaurants.FirstOrDefault(x => x.Id == id);
    }

    public PaginatedResultDTO<Restaurant> GetAllRestaurants(RestaurantQuery query)
    {
        // Start with all restaurants
        var restaurants = allRestaurants
            .Where(r => query.Address == null || r.Address == query.Address)
            .Where(r => query.Name == null || r.Name.Contains(query.Name))
            .Where(r => query.IsActive == null || r.IsActive == query.IsActive);

        // Get total count BEFORE pagination
        var totalCount = restaurants.Count();
        // Apply pagination
        var items = restaurants
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToList();
           // Return paginated result
        return new PaginatedResultDTO<Restaurant>
        {
            Items = items,
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize
        };
    }
}