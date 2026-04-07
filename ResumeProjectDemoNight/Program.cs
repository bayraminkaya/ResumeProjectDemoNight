using Microsoft.EntityFrameworkCore;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext - appsettings'den connection string oku
builder.Services.AddDbContext<ResumeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Session ekle
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Controller'ları ve Admin Filter'ı ekle
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AdminAuthFilter>();
});

var app = builder.Build();

// 🔄 Otomatik Migration - Veritabanını güncelle
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ResumeContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Session middleware
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();