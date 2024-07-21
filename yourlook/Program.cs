using Data.Models;
using Microsoft.EntityFrameworkCore;
using yourlook.MenuKid;

var builder = WebApplication.CreateBuilder(args);
//
builder.Services.AddDbContext<YourlookContext>(options =>
{
    //options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectedDb"]);
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectedDb"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

//add Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

//builder ViewComponent
builder.Services.AddScoped<ISanPhamHot, SanPhamHot>();
builder.Services.AddScoped<ICategory, Category>();
builder.Services.AddScoped<ISanPhamNew, SanPhamNew>();
builder.Services.AddScoped<IAds, Ads>();
builder.Services.AddScoped<IPage1, Page1>();
builder.Services.AddScoped<IPage2, Page2>();
builder.Services.AddScoped<IPage3, Page3>();
builder.Services.AddScoped<IPage4, Page4>();
//builder.Services.AddScoped<>
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
