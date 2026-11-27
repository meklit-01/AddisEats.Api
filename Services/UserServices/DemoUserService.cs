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
        var customer2 = new User
        {
            Id = 2,
            FullName = "Dawit Bekele",
            Phone = "0922345678",
            Role = "Customer",
            IsVerified = true
        };
        customer2.PasswordHash = hasher.HashPassword(customer2, "Addis@123");
        _users.Add(customer2);


        var customer3 = new User
        {
            Id = 3,
            FullName = "Hana Tesfaye",
            Phone = "0933456789",
            Role = "Customer",
            IsVerified = false
        };
        customer3.PasswordHash = hasher.HashPassword(customer3, "Addis@123");
        _users.Add(customer3);

    } 

    public User? FindByPhone(string phone)
    {
       return _users.FirstOrDefault(x => x.Phone == phone);
    }
}