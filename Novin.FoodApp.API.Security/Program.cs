using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Novin.FoodApp.API.Security.DTOs;
using Novin.FoodApp.Core.Entities;
using Novin.FoodApp.Core.Enums;
using Novin.FoodApp.Infrastructure.Data;
using Novin.FoodApp.Infrastructure.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);
var app = builder.Build();
SecurityServices.UseServices(app);

app.MapPost("/signup", async (NovinFoodAppDB db, ApplicationUser user) =>
{
    var rg = new Random();
    user.VerificationCode = rg.Next(100000, 999999).ToString();
    //send sms
    await db.ApplicationUsers.AddAsync(user);
    await db.SaveChangesAsync();
    return Results.Ok();

});
app.MapPost("/signin", async (NovinFoodAppDB db, LoginDto login) =>
{
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(a => a.Type!=ApplicationUserType.SystemAdmin && a.Verifide == true && a.Username == login.Username && a.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto
        {
            Message = "username or password is incorrect",
            IsOk = false
        });
    }
    var claims = new[]
    {
        new Claim("Type",result.Type.ToString()),
        new Claim("Username",result.Username.ToString()),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"] ?? ""));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        builder.Configuration["Jwt:Issuer"],
        builder.Configuration["Jwt:Audience"],
        claims,
        expires: DateTime.UtcNow.AddDays(3),
        signingCredentials: signIn);
    return Results.Ok(new LoginResultDto
    {
        Message = "welcome",
        IsOk = true,
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Type = result.Type.ToString(),
    });
});
app.MapPost("/adminsignin", async (NovinFoodAppDB db, LoginDto login) =>
{
    if (!db.ApplicationUsers.Any())
    {
        await db.ApplicationUsers.AddAsync(new ApplicationUser
        {
            Verifide = true,
            VerificationCode = "11111111",
            Email = "admin@admin",
            Fullname = "app Admin",
            Password = "45464546",
            Username = "admin",
            PhoneNumber = "00000000000",
            Type = ApplicationUserType.SystemAdmin
        });
        await db.SaveChangesAsync();
    }

    var result = await db.ApplicationUsers.FirstOrDefaultAsync(a => a.Type==ApplicationUserType.SystemAdmin && a.Verifide == true && a.Username == login.Username && a.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto
        {
            Message = "username or password is incorrect",
            IsOk = false
        });
    }
    var claims = new[]
    {
        new Claim("Type",result.Type.ToString()),
        new Claim("Username",result.Username.ToString()),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"] ?? ""));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        builder.Configuration["Jwt:Issuer"],
        builder.Configuration["Jwt:Audience"],
        claims,
        expires: DateTime.UtcNow.AddDays(3),
        signingCredentials: signIn);
    return Results.Ok(new LoginResultDto
    {
        Message = "welcome",
        IsOk = true,
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Type = result.Type.ToString(),
    });
});

app.Run();
