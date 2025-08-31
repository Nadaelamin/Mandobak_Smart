using Mandobak_Smart.Data;
using Mandobak_Smart.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Mandobak_Smart.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Add Controllers
builder.Services.AddControllers();

// ✅ Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mandobak API", Version = "v1" });
});

// Add Services
builder.Services.AddScoped<CartService>();

var app = builder.Build();

// ✅ Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mandobak API V1");
        c.RoutePrefix = "swagger";
    });
}

// ✅ Run DB Seeding in a single scope to avoid FK issues
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var context = services.GetRequiredService<AppDbContext>();

    // 🔹 Seed Users first
    await DbInitializer.SeedUsers(userManager);

    // 🔹 Seed Categories, SubCategories, Products
    DbInitializer.SeedCategories(context);

    // 🔹 Seed Companies
    DbInitializer.SeedCompanies(context);

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
