using AddisEats.Api.Services.OrderService;
using AddisEats.Api.DTOs;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AddisEats.Api.Authorization;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IAuthorizationService _authorizationService;

    public OrderController(
    IOrderService orderService,
    IAuthorizationService authorizationService)
    {
        _orderService = orderService;
        _authorizationService = authorizationService;
    }
    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id)
    {
        var order = _orderService.GetById(id);
        if(order == null)
        {
            return NotFound();
        }

        var result = await _authorizationService.AuthorizeAsync(
                User,
                order,
                OrderOperations.Read
            );
        if (!result.Succeeded) 
        {
            return Forbid();
        }

        return Ok(order);
    }
    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDTO createDTO)
    {
        var result = _orderService.CreateOrder(createDTO);
        if (!result.IsSuccess) {
            return Problem(
                title: result.Error?.Message,
                statusCode: result.Error?.Status,
                detail: result.Error?.Code
                );
        }

        var order = result.Value;

        return CreatedAtAction(
            nameof(GetById),
            new { id = order.Id }, order);
    }
}