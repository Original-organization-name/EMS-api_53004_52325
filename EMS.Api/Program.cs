using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using EMS.Api;
using EMS.Api.Filters;
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
    .AddApplicationPart(typeof(EMS.Presentation.AssemblyReference).Assembly)
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
});

builder.Services.AddDbContext<DatabaseContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IBaseEditableDictRepository<>), typeof(BaseEditableDictRepository<>));
builder.Services.AddScoped(typeof(IBaseEditableDictService<>), typeof(BaseEditableDictService<>));

var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(typeof(EMS.DTO.AssemblyReference).Assembly);
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
});;

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

app.UseCors("AllowSpecificOrigin");

app.Seed();
app.Run();