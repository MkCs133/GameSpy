using GameSpy.Areas.Identity.Data;
using GameSpy.Models;
using GameSpy.Service.GameS;
using GameSpy.Service.PcS;
using GameSpy.Service.UserS;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GameSpyContextConnection") ?? throw new InvalidOperationException("Connection string 'GameSpyContextConnection' not found.");


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GameSpyContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GameSpyContext>()
    .AddSignInManager<MySIgnInManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IPcService, PcService>();

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

app.MapRazorPages();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
