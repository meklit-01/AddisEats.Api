using AddisEats.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace AddisEats.Api.Services.UserServices;

public class DemoUserService
{
    private readonly List<User> _users = new ();

    public DemoUserService(IPasswordHasher<User> hasher)
    {
        var customer = new User
        {
            Id = 1,
            FullName = "Almaz Neway",
            Phone = "0911234567",
            Role = "Customer",
            IsVerified = true
        };
        customer.PasswordHash = hasher.HashPassword(customer, "Addis@123");
        _users.Add(customer);

    } 

    public User? FindByPhone(string phone)
    {
       return _users.FirstOrDefault(x => x.Phone == phone);
    }
}