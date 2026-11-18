using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Common;
using AddisEats.Api.Services.RestaurantService;

namespace AddisEats.Api.Services.OrderService;

public class OrderService : IOrderService
{
    private static readonly List<Order> _orders = new List<Order>();

    private static int _nextId = 1;
    private readonly IRestaurantService _restaurantService;

    public OrderService(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public Order? GetById(int id)
    {
        return _orders.FirstOrDefault(ob => ob.Id == id);
    }

    public Result<Order> CreateOrder(CreateOrderDTO createDTO)
    {
        var restaurant = _restaurantService.GetRestaurantById(createDTO.RestaurantId);
        if (restaurant is null) {
            return Result<Order>.Fail("RESTAURANT_NOT_FOUND", "The selecte restaurant does not exist.", 404);
        }
        Order o = new Order
        {
            Id = _nextId++,
            RestaurantId = createDTO.RestaurantId,
            MenuItemId = createDTO.MenuItemId,
            CustomerName = createDTO.CustomerName,
            DeliveryAddress = createDTO.DeliveryAddress,
            CustomerPhone = createDTO.CustomerPhone,
            Quantity = createDTO.Quantity,
            TotalAmount = createDTO.TotalAmount,
        };

        _orders.Add(o);
        return Result<Order>.Ok(o);// this Ok is not the status function Ok it is from the common result like fail
    }
}
