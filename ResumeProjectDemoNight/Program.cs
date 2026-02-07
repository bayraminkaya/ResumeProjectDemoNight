using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ResumeContext>();

// Session ekle
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24); // 24 saat session süresi
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Controller'larý ve Admin Filter'ý ekle
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AdminAuthFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Session middleware - UseRouting'den sonra, UseAuthorization'dan önce
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();