using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.PersistenceLayer;

public static class DataSeeder
{
    public static WebApplication Seed(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<RecordsDbContext>();
        context.Database.EnsureCreated();

        SeedMedicalExamDict(context);
        SeedTrainingDict(context);

        context.SaveChanges();

        return app;
    }

    private static void SeedMedicalExamDict(RecordsDbContext context)
    {
        if (!context.MedicalExamDict.Any())
        {
            context.MedicalExamDict.AddRange(
                new MedicalExamItem() { Value = "Preliminary" },
                new MedicalExamItem() { Value = "Periodic" },
                new MedicalExamItem() { Value = "Control" },
                new MedicalExamItem() { Value = "Final" }
            );
        }
    }

    private static void SeedTrainingDict(RecordsDbContext context)
    {
        if (!context.TrainingDict.Any())
        {
            context.TrainingDict.AddRange(
                new TrainingItem() { Value = "Initial BHP Training" },
                new TrainingItem() { Value = "Periodic BHP Training" }
            );
        }
    }
}