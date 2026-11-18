using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Validation;
namespace AddisEats.Api.DTOs;

public record CreateOrderDTO(
    [Range(1, int.MaxValue, ErrorMessage = "Restaurant ID must be a positive integer.")]
    int RestaurantId,
    int MenuItemId,
    [Required(ErrorMessage = "Customer name is required.")]
    string CustomerName,
    [StringLength(60, MinimumLength = 1, ErrorMessage = "Delivery address must be minmum length of 1")]
    string DeliveryAddress,
    [Required(ErrorMessage = "Customer phone is required.")]
    [EthiopianMobile]
    string CustomerPhone,
    [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50.")]
    int Quantity,
    [Required(ErrorMessage = "Total amount is required.")]
    [ETBAmount]
    decimal TotalAmount
);
