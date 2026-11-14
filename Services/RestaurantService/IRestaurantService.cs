using AddisEats.Api.Models;

namespace AddisEats.Api.Services.RestaurantService;

public interface IRestaurantService
{
    Restaurant? GetRestaurantById(int id);
    List<Restaurant> GetAllRestaurants(string? addres, int page, int pageSize);
 }
