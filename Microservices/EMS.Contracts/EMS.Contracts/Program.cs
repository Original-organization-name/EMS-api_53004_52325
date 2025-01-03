using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.PersistenceLayer;
using EMS.Contracts.PersistenceLayer.Repositories;
using EMS.Contracts.Services;
using EMS.Shared.Helpers;
using EMS.Shared.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithOptions()
    .ScanMapperRegisters()
    .AddSwagger()
    .AddAllCors();

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllCors");

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ContractsDbContext>();
    dbContext.Database.Migrate();
}

app.Seed();

app.Run();

