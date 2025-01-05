using EMS.Shared.Helpers;
using EMS.Shared.Middlewares;
using EMS.EventBus.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithOptions()
    .AddEventBus()
    .AddSwagger()
    .AddAllCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();