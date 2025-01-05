using EMS.Shared.Helpers;
using EMS.Employees.Abstractions.Repositories;
using EMS.Employees.Abstractions.Services;
using EMS.Employees.PersistenceLayer;
using EMS.Employees.PersistenceLayer.Repositories;
using EMS.Employees.Services;
using EMS.EventBus.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services
    .ScanMapperRegisters()
    .AddEventBus();

builder.Services.AddDbContext<EmployeeDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    dbContext.Database.Migrate();
}

app.Run();