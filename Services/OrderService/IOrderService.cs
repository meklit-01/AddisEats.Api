using AddisEats.Api.Models;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Services.OrderService;

public interface IOrderService
{
	Order? GetById(int id);
	Order CreateOrder(CreateOrderDTO createDTO);
}