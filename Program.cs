using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Customers;
using NauticaFreight.API.Data;
using NauticaFreight.API.Mappings;
using NauticaFreight.API.Ports;
using NauticaFreight.API.Trips;
using NauticaFreight.API.Vessels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);
//builder.Services.AddFastEndpoints();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICustomerRepository, CustomerImpl>();
builder.Services.AddScoped<IPortRepository, PortRepository>();
builder.Services.AddScoped<IVesselsRepository, VesselsRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

//app.UseFastEndpoints();

ApplyMigration();

app.Run();



//Method to automatucally add a migration
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (dbContext.Database.GetPendingMigrations().Count() > 0)
        {
            dbContext.Database.Migrate();
        }
        dbContext.Database.Migrate();
    }
}

