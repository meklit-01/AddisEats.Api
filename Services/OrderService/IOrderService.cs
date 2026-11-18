using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Common;

namespace AddisEats.Api.Services.OrderService;

public interface IOrderService
{
	Order? GetById(int id);
	Result<Order> CreateOrder(CreateOrderDTO createDTO);
}