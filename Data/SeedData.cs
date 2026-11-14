
using AddisEats.Api.Models;

namespace AddisEats.Api.Data;

public class SeedData
{
    public static List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant { Id = 1, Name = "Addis Ababa Restaurant", Address = "Bole", Phone = "555-1234", IsActive = true, OwnerAddress = "456 Elm St" },
        new Restaurant { Id = 2, Name = "Blue Nile Restaurant", Address = "Ayat", Phone = "555-5678", IsActive = false, OwnerAddress = "789 Pine St" },
        new Restaurant { Id = 3, Name = "Lucy Restaurant", Address = "Mexico", Phone = "555-9012", IsActive = true, OwnerAddress = "321 Cedar St" },
        new Restaurant { Id = 4, Name = "Ethio Restaurant", Address = "Megenagna", Phone = "555-3456", IsActive = true, OwnerAddress = "654 Spruce St" },
        new Restaurant { Id = 5, Name = "Tena Yistilign Restaurant", Address = "Bole", Phone = "555-7890", IsActive = true, OwnerAddress = "987 Birch St" },
        new Restaurant { Id = 6, Name = "Kategna Restaurant", Address = "Megenagna", Phone = "555-2345", IsActive = true, OwnerAddress = "123 Main St" },
        new Restaurant { Id = 7, Name = "Sishu Restaurant", Address = "Bole", Phone = "555-6789", IsActive = false, OwnerAddress = "246 Aspen St" },
        new Restaurant { Id = 8, Name = "Abay Restaurant", Address = "Megenagna", Phone = "555-0123", IsActive = true, OwnerAddress = "357 Cherry St" },
        new Restaurant { Id = 9, Name = "Fendika Restaurant", Address = "Mexico", Phone = "555-4567", IsActive = false, OwnerAddress = "468 Walnut St" },
        new Restaurant { Id = 10, Name = "Doro Wat Restaurant", Address = "Megenagna", Phone = "555-8901", IsActive = true, OwnerAddress = "579 Chestnut St" },
        new Restaurant { Id = 11, Name = "Injera Restaurant", Address = "Mexico", Phone = "555-2345", IsActive = true, OwnerAddress = "680 Poplar St" },
        new Restaurant { Id = 12, Name = "Bunna Restaurant", Address = "Ayat", Phone = "555-6789", IsActive = true, OwnerAddress = "791 Fir St" }
    };

    public static List<MenuItem> MenuItems = new List<MenuItem>
    {
        // Restaurant 1
        new MenuItem { Id = 1, RestaurantId = 1, Name = "Doro Wet", Category = "Traditional", Price = 250 },
        new MenuItem { Id = 2, RestaurantId = 1, Name = "Shiro", Category = "Traditional", Price = 150 },
        new MenuItem { Id = 3, RestaurantId = 1, Name = "Tibs", Category = "Traditional", Price = 300 },

        // Restaurant 2
        new MenuItem { Id = 4, RestaurantId = 2, Name = "Kitfo", Category = "Traditional", Price = 350 },
        new MenuItem { Id = 5, RestaurantId = 2, Name = "Gored Gored", Category = "Traditional", Price = 380 },
        new MenuItem { Id = 6, RestaurantId = 2, Name = "Firfir", Category = "Breakfast", Price = 120 },

        // Restaurant 3
        new MenuItem { Id = 7, RestaurantId = 3, Name = "Chechebsa", Category = "Breakfast", Price = 130 },
        new MenuItem { Id = 8, RestaurantId = 3, Name = "Beyaynet", Category = "Traditional", Price = 220 },
        new MenuItem { Id = 9, RestaurantId = 3, Name = "Misir Wot", Category = "Traditional", Price = 140 },

        // Restaurant 4
        new MenuItem { Id = 10, RestaurantId = 4, Name = "Pasta", Category = "Main Course", Price = 200 },
        new MenuItem { Id = 11, RestaurantId = 4, Name = "Pizza", Category = "Fast Food", Price = 450 },
        new MenuItem { Id = 12, RestaurantId = 4, Name = "Cheeseburger", Category = "Fast Food", Price = 280 },

        // Restaurant 5
        new MenuItem { Id = 13, RestaurantId = 5, Name = "French Fries", Category = "Side Dish", Price = 100 },
        new MenuItem { Id = 14, RestaurantId = 5, Name = "Grilled Chicken", Category = "Main Course", Price = 320 },
        new MenuItem { Id = 15, RestaurantId = 5, Name = "Caesar Salad", Category = "Salad", Price = 180 },

        // Restaurant 6
        new MenuItem { Id = 16, RestaurantId = 6, Name = "Fresh Juice", Category = "Drinks", Price = 90 },
        new MenuItem { Id = 17, RestaurantId = 6, Name = "Coffee", Category = "Drinks", Price = 40 },
        new MenuItem { Id = 18, RestaurantId = 6, Name = "Fruit Salad", Category = "Dessert", Price = 150 },

        // Restaurant 7
        new MenuItem { Id = 19, RestaurantId = 7, Name = "Doro Wet", Category = "Traditional", Price = 270 },
        new MenuItem { Id = 20, RestaurantId = 7, Name = "Kitfo", Category = "Traditional", Price = 380 },
        new MenuItem { Id = 21, RestaurantId = 7, Name = "Injera Firfir", Category = "Breakfast", Price = 140 },

        // Restaurant 8
        new MenuItem { Id = 22, RestaurantId = 8, Name = "Special Tibs", Category = "Traditional", Price = 400 },
        new MenuItem { Id = 23, RestaurantId = 8, Name = "Shiro", Category = "Traditional", Price = 160 },
        new MenuItem { Id = 24, RestaurantId = 8, Name = "Pasta", Category = "Main Course", Price = 220 },

        // Restaurant 9
        new MenuItem { Id = 25, RestaurantId = 9, Name = "Pizza", Category = "Fast Food", Price = 480 },
        new MenuItem { Id = 26, RestaurantId = 9, Name = "Cheeseburger", Category = "Fast Food", Price = 300 },
        new MenuItem { Id = 27, RestaurantId = 9, Name = "French Fries", Category = "Side Dish", Price = 110 },

        // Restaurant 10
        new MenuItem { Id = 28, RestaurantId = 10, Name = "Grilled Chicken", Category = "Main Course", Price = 350 },
        new MenuItem { Id = 29, RestaurantId = 10, Name = "Caesar Salad", Category = "Salad", Price = 200 },
        new MenuItem { Id = 30, RestaurantId = 10, Name = "Fresh Juice", Category = "Drinks", Price = 100 },

        // Restaurant 11
        new MenuItem { Id = 31, RestaurantId = 11, Name = "Beyaynet", Category = "Traditional", Price = 230 },
        new MenuItem { Id = 32, RestaurantId = 11, Name = "Misir Wot", Category = "Traditional", Price = 150 },
        new MenuItem { Id = 33, RestaurantId = 11, Name = "Coffee", Category = "Drinks", Price = 50 },

        // Restaurant 12
        new MenuItem { Id = 34, RestaurantId = 12, Name = "Doro Wet", Category = "Traditional", Price = 260 },
        new MenuItem { Id = 35, RestaurantId = 12, Name = "Tibs", Category = "Traditional", Price = 320 },
        new MenuItem { Id = 36, RestaurantId = 12, Name = "Fruit Salad", Category = "Dessert", Price = 160 }
    };
}
