using System.Text;
using System.Reflection;
using AddisEats.Api.Services.RestaurantService;
using AddisEats.Api.Services.MenuItemService;
using AddisEats.Api.Services.OrderService;
using AddisEats.Api.Configuration;
using AddisEats.Api.Services.UserServices;
using AddisEats.Api.Services.AuthServices;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(options =>
{
    // API information
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Addis Eats API",
        Version = "v1",
        Description = "Ordering and delivery API for restaurants in Addis Ababa."
    });

    // Include XML comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);

    // Add JWT Bearer authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token only (without the 'Bearer ' prefix)."
    });

    // Require JWT authentication in Swagger
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer",document)] = []
    });
});

// Register application services
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Configure JWT settings
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt"));

// Register authentication services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DemoUserService>();

builder.Services.AddScoped<IPasswordHasher<User>,
    PasswordHasher<User>>();

// Read JWT settings
var jwt = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtOptions>()
    ?? throw new InvalidOperationException(
        "JWT settings are missing.");

// Check signing key
if (string.IsNullOrWhiteSpace(jwt.SigningKey))
{
    throw new InvalidOperationException(
        "JWT SigningKey is missing.");
}

// Configure JWT authentication
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwt.Issuer,

                ValidateAudience = true,
                ValidAudience = jwt.Audience,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30),

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwt.SigningKey))
            };
    });

// Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("VerifiedCustomer", policy =>
    //{
    //    policy.RequireRole("Customer");
    //    policy.RequireClaim("IsVerified", "true");
    //});

    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
} );

var app = builder.Build();

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
