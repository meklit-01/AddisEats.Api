using AddisEats.Api.Services.RestaurantService;
using AddisEats.Api.Services.MenuItemService; 
using AddisEats.Api.Services.OrderService;
using AddisEates.Api.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//this gives endpoint explorer  UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt"
    );

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()!;

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
