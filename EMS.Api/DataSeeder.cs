using EMS.Data.Dictionaries;
using EMS.PersistenceLayer;

namespace EMS.Api;

public static class DataSeeder
{
    public static WebApplication Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            try
            {
                context.Database.EnsureCreated();

                SeedMedicalExamDict(context);
                SeedTrainingDict(context);

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        return app;
    }

    private static void SeedMedicalExamDict(DatabaseContext context)
    {
        if (!context.MedicalExamDict.Any())
        {
            context.MedicalExamDict.AddRange(
                new MedicalExamItem() {Value = "Preliminary"},
                new MedicalExamItem() {Value = "Periodic"},
                new MedicalExamItem() {Value = "Control"},
                new MedicalExamItem() {Value = "Final"}
            );
        }
    }
    private static void SeedTrainingDict(DatabaseContext context)
    {
        if (!context.TrainingDict.Any())
        {
            context.TrainingDict.AddRange(
                new TrainingItem() {Value = "Initial BHP Training"},
                new TrainingItem() {Value = "Periodic BHP Training"}
            );
        }
    }
}