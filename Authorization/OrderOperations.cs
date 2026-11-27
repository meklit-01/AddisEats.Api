using Microsoft.AspNetCore.Authorization.Infrastructure;


public static class OrderOperations
{
    public static readonly OperationAuthorizationRequirement Read =
    new()
    {
        Name = nameof(Read)
    };
    
}


