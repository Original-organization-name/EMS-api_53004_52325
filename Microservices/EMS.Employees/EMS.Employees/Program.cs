using EMS.Shared.Helpers;
using EMS.Shared.Middlewares;
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
    .AddControllersWithOptions()
    .ScanMapperRegisters()
    .AddEventBus()
    .AddSwagger()
    .AddAllCors();

builder.Services.AddDbContext<EmployeeDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllCors");

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    dbContext.Database.Migrate();
}

app.Run();