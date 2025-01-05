using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.PersistenceLayer;
using EMS.Contracts.PersistenceLayer.Repositories;
using EMS.Contracts.Services;
using EMS.EventBus.Extensions;
using EMS.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services
    .ScanMapperRegisters()
    .AddEventBus();

builder.Services.AddDbContext<ContractsDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IOccupationDictService, OccupationDictService>();
builder.Services.AddScoped<IWorkplaceItemService, WorkplaceItemService>();
builder.Services.AddScoped<IPositionItemService, PositionItemService>();
builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddScoped<IOccupationDictRepository, OccupationDictRepository>();
builder.Services.AddScoped<IWorkplaceItemRepository, WorkplaceItemRepository>();
builder.Services.AddScoped<IPositionItemRepository, PositionItemRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ContractsDbContext>();
    dbContext.Database.Migrate();
}

app.Seed();

app.Run();

