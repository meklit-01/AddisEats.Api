using AddisEats.Api.Models;
using AddisEats.Api.DTOs;


namespace AddisEats.Api.Services.RestaurantService;

public interface IRestaurantService
{
    Restaurant? GetRestaurantById(int id);
    PaginatedResultDTO<Restaurant> GetAllRestaurants(RestaurantQuery query);
}
