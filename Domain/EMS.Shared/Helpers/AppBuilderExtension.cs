using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using EMS.Shared.Filters;
using EMS.Shared.Middlewares;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Shared.Helpers;

public static class AppBuilderExtension
{
    public static IServiceCollection AddControllersWithOptions(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
        
        services.AddTransient<ExceptionHandlingMiddleware>();

        return services;
    }
    
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {                     
            c.SupportNonNullableReferenceTypes();
            c.SchemaFilter<RequiredSchemaFilter>();
            c.CustomSchemaIds(x => x.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault()?.DisplayName ?? x.Name);
            c.UseAllOfToExtendReferenceSchemas();
        });
        
        return services;
    }
    
    public static IServiceCollection ScanMapperRegisters(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(Assembly.GetCallingAssembly());
        services.AddSingleton<IMapper>(new Mapper(typeAdapterConfig));

        return services;
    }
    
    public static IServiceCollection AddAllCors(this IServiceCollection services)
    {
       services.AddCors(options =>
       {
           options.AddPolicy("AllCors",
               cors =>
               {
                   cors.AllowAnyOrigin() 
                       .AllowAnyHeader()
                       .AllowAnyMethod();
               });
       });
       
       return services;
    }
}