using AddisEats.Api.Models;
using AddisEats.Api.Data;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.RestaurantService;

public class RestaurantService : IRestaurantService
{
    private readonly List<Restaurant> allRestaurants = SeedData.restaurants;

    public Restaurant? GetRestaurantById(int id)
    {
        return allRestaurants.FirstOrDefault(x => x.Id == id);
    }

    public List<Restaurant> GetAllRestaurants([FromQuery] RestaurantQuery query)
    {
        var restaurants = allRestaurants
            .Where(r => query.Address == null || r.Address == query.Address)
            .Where(r => query.Name == null || r.Name.Contains(query.Name))
             .Where(r => query.IsActive == null || r.IsActive == query.IsActive)
            .Take(query.PageSize)
            .ToList();

        return restaurants;
    }
}