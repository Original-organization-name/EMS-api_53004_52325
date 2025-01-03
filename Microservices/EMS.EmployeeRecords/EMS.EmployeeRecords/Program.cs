using EMS.Domain.Helpers;
using EMS.Domain.Middlewares;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.PersistenceLayer;
using EMS.EmployeeRecords.PersistenceLayer.Repositories;
using EMS.EmployeeRecords.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithOptions()
    .ScanMapperRegisters()
    .AddSwagger()
    .AddAllCors();

builder.Services.AddDbContext<RecordsDbContext>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IMedicalExaminationService, MedicalExaminationService>();
builder.Services.AddScoped<IQualificationItemService, QualificationItemService>();
builder.Services.AddScoped<IMedicalExamItemService, MedicalExamItemService>();
builder.Services.AddScoped<IQualificationService, QualificationService>();
builder.Services.AddScoped<ITrainingItemService, TrainingItemService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();

builder.Services.AddScoped<IMedicalExaminationRepository, MedicalExaminationRepository>();
builder.Services.AddScoped<IQualificationItemRepository, QualificationItemRepository>();
builder.Services.AddScoped<IMedicalExamItemRepository, MedicalExamItemRepository>();
builder.Services.AddScoped<IQualificationRepository, QualificationRepository>();
builder.Services.AddScoped<ITrainingItemRepository, TrainingItemRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();

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
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<RecordsDbContext>();
    dbContext.Database.Migrate();
}

app.Seed();

app.Run();