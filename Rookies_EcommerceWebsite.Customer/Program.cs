using Rookies_EcommerceWebsite.Customer.Models;
using Rookies_EcommerceWebsite.Customer.RequestSender;
using Rookies_EcommerceWebsite.Customer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRequestSender<Product>, RequestSender<Product>>();
builder.Services.AddTransient<IRequestSender<Category>, RequestSender<Category>>();
builder.Services.AddTransient<IRequestSender<Rating>, RequestSender<Rating>>();
builder.Services.AddTransient<IAuthRequestSender, AuthRequestSender>();

builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<RatingService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
