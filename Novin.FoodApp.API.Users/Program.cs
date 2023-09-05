using Microsoft.EntityFrameworkCore;
using Novin.FoodApp.Infrastructure.Data;
using Novin.FoodApp.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);
var app = builder.Build();
SecurityServices.UseServices(app);
app.MapPost("/list", async (NovinFoodAppDB db) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());
});

app.Run();
