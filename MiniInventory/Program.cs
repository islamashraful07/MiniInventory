using Microsoft.EntityFrameworkCore;
using MiniInventory.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MiniInventory.Repositories.Interfaces.IProductRepositories, MiniInventory.Repositories.Implementations.ProductRepositories>();
builder.Services.AddScoped<MiniInventory.Services.Interfaces.IProductServices, MiniInventory.Services.Implementations.ProductServices>();
builder.Services.AddAutoMapper(typeof(CustomDtoMapper));
// Register db context
builder.Services.AddDbContext<Datacontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Automapper configuration


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
