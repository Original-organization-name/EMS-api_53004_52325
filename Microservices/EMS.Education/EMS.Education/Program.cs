using EMS.Shared.Helpers;
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
    .ScanMapperRegisters()
    .AddEventBus();

builder.Services.AddDbContext<EducationDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IEducationService, EducationService>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<EducationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();