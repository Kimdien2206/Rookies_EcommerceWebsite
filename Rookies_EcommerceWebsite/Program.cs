using Rookies_EcommerceWebsite.Data;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Repositories;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject ConnectionString.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString));

// Inject Identity framework.
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureAll<BearerTokenOptions>(option => {
    option.BearerTokenExpiration = TimeSpan.FromDays(14);
});


builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
//builder.Services.AddScoped<IPasswordHasher<IdentityUser>, PasswordHasher<IdentityUser>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
