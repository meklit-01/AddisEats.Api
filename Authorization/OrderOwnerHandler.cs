using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using AddisEats.Api.Models;

namespace AddisEats.Api.Authorization;

public class OrderOwnerHandler : AuthorizationHandler<OperationAuthorizationRequirement, Order>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OperationAuthorizationRequirement requirement,
        Order order)
    {
        var userId = context.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        if (context.User.IsInRole("Customer") &&
            order.CustomerId.ToString() == userId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}