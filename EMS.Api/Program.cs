using EMS.Api;
using EMS.Api.Middleware;
using EMS.PersistenceLayer;
using EMS.PersistenceLayer.Repositories;
using EMS.Services;
using EMS.Services.Dictionaries;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(EMS.Presentation.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IBaseEditableDictRepository<>), typeof(BaseEditableDictRepository<>));
builder.Services.AddScoped(typeof(IBaseEditableDictService<>), typeof(BaseEditableDictService<>));

var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(typeof(EMS.Contracts.AssemblyReference).Assembly);
builder.Services.AddSingleton<IMapper>(new Mapper(typeAdapterConfig));

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

using (var context = new DatabaseContext())
{
    context.Database.Migrate();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Seed();
app.Run();