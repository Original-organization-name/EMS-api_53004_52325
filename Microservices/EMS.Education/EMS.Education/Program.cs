using EMS.Shared.Helpers;
using EMS.Shared.Middlewares;
using EMS.Education.Abstractions.Repositories;
using EMS.Education.Abstractions.Services;
using EMS.Education.PersistenceLayer;
using EMS.Education.PersistenceLayer.Repositories;
using EMS.Education.Services;
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

builder.Services.AddDbContext<EducationDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IEducationService, EducationService>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();

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
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<EducationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();