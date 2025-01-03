using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.PersistenceLayer;
using EMS.Contracts.Repositories;
using EMS.Contracts.Services;
using EMS.Domain.Filters;
using EMS.Domain.Middlewares;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{                     
    c.SupportNonNullableReferenceTypes();
    c.SchemaFilter<RequiredSchemaFilter>();
    c.CustomSchemaIds(x => x.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault()?.DisplayName ?? x.Name);
    c.UseAllOfToExtendReferenceSchemas();
});

builder.Services.AddDbContext<ContractsDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IOccupationDictService, OccupationDictService>();
builder.Services.AddScoped<IWorkplaceItemService, WorkplaceItemService>();
builder.Services.AddScoped<IPositionItemService, PositionItemService>();
builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddScoped<IOccupationDictRepository, OccupationDictRepository>();
builder.Services.AddScoped<IWorkplaceItemRepository, WorkplaceItemRepository>();
builder.Services.AddScoped<IPositionItemRepository, PositionItemRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();

var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<IMapper>(new Mapper(typeAdapterConfig));

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        cors =>
        {
            cors.AllowAnyOrigin() 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

using (var context = new ContractsDbContext())
{
    context.Database.Migrate();
}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Seed();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ContractsDbContext>();
    dbContext.Database.Migrate();
}

app.Run();

