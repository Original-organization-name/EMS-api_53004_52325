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
                SeedOccupationCodeDict(context);
                SeedPositionDict(context);
                SeedWorkplaceDict(context);
                
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
    
    private static void SeedPositionDict(DatabaseContext context)
    {
        if (!context.PositionDict.Any())
        {
            context.PositionDict.AddRange(
                new PositionItem() {Value = "C# developer"},
                new PositionItem() {Value = "Angular developer"}
            );
        }
    }
    
    private static void SeedWorkplaceDict(DatabaseContext context)
    {
        if (!context.WorkplaceDict.Any())
        {
            context.WorkplaceDict.AddRange(
                new WorkplaceItem() {Value = "Office 1" },
                new WorkplaceItem() {Value = "Office 2"}
            );
        }
    }
    
    private static void SeedOccupationCodeDict(DatabaseContext context)
    {
        if (!context.OccupationCodeDict.Any())
        {
            context.OccupationCodeDict.AddRange(
            new OccupationCodeItem() { Code = "252101", Value = "Administrator baz danych" },
                new OccupationCodeItem() { Code = "333403", Value = "Administrator nieruchomości" },
                new OccupationCodeItem() { Code = "242101", Value = "Administrator produkcji filmowej" },
                new OccupationCodeItem() { Code = "351401", Value = "Administrator stron internetowych" },
                new OccupationCodeItem() { Code = "252201", Value = "Administrator systemów komputerowych" },
                new OccupationCodeItem() { Code = "351402", Value = "Administrator systemów poczty elektronicznej" },
                new OccupationCodeItem() { Code = "252202", Value = "Administrator zintegrowanych systemów zarządzania" },
                new OccupationCodeItem() { Code = "261101", Value = "Adwokat" },
                new OccupationCodeItem() { Code = "333101", Value = "Agent celny" },
                new OccupationCodeItem() { Code = "333401", Value = "Agent do spraw pozyskiwania gruntów" },
                new OccupationCodeItem() { Code = "332301", Value = "Agent do spraw zakupów" },
                new OccupationCodeItem() { Code = "333102", Value = "Agent klarujący" },
                new OccupationCodeItem() { Code = "332101", Value = "Agent ubezpieczeniowy" },
                new OccupationCodeItem() { Code = "211303", Value = "Agrochemik" },
                new OccupationCodeItem() { Code = "334301", Value = "Akredytowany asystent parlamentarny" },
                new OccupationCodeItem() { Code = "343501", Value = "Akrobata" },
                new OccupationCodeItem() { Code = "265501", Value = "Aktor" },
                new OccupationCodeItem() { Code = "343502", Value = "Aktor cyrkowy S" },
                new OccupationCodeItem() { Code = "265502", Value = "Aktor lalkarz" },
                new OccupationCodeItem() { Code = "343601", Value = "Aktor scen muzycznych S" },
                new OccupationCodeItem() { Code = "212001", Value = "Aktuariusz" },
                new OccupationCodeItem() { Code = "323001", Value = "Akupunkturzysta" },
                new OccupationCodeItem() { Code = "524301", Value = "Akwizytor" },
                new OccupationCodeItem() { Code = "713301", Value = "Alpinista przemysłowy" },
                new OccupationCodeItem() { Code = "252102", Value = "Analityk baz danych (data scientist)" },
                new OccupationCodeItem() { Code = "242112", Value = "Analityk biznesowy" },
                new OccupationCodeItem() { Code = "251104", Value = "Analityk doświadczenia użytkowników (user experience analyst)" },
                new OccupationCodeItem() { Code = "241306", Value = "Analityk finansowy" },
                new OccupationCodeItem() { Code = "241301", Value = "Analityk giełdowy" },
                new OccupationCodeItem() { Code = "262201", Value = "Analityk informacji i raportów medialnych" },
                new OccupationCodeItem() { Code = "241311", Value = "Analityk inwestycyjny" },
                new OccupationCodeItem() { Code = "241302", Value = "Analityk kredytowy" },
                new OccupationCodeItem() { Code = "261911", Value = "Analityk kryminalny" },
                new OccupationCodeItem() { Code = "242301", Value = "Analityk pracy" },
                new OccupationCodeItem() { Code = "262202", Value = "Analityk ruchu na stronach internetowych" },
                new OccupationCodeItem() { Code = "252301", Value = "Analityk sieci komputerowych" },
                new OccupationCodeItem() { Code = "251101", Value = "Analityk systemów teleinformatycznych" },
                new OccupationCodeItem() { Code = "243101", Value = "Analityk trendów rynkowych (cool hunter)" },
                new OccupationCodeItem() { Code = "235101", Value = "Andragog" },
                new OccupationCodeItem() { Code = "235916", Value = "Animator czasu wolnego młodzieży (pracownik młodzieżowy)" },
                new OccupationCodeItem() { Code = "242201", Value = "Animator gospodarczy do spraw przedsiębiorczości" },
                new OccupationCodeItem() { Code = "242202", Value = "Animator gospodarczy do spraw rozwoju regionalnego" },
                new OccupationCodeItem() { Code = "343901", Value = "Animator kultury" },
                new OccupationCodeItem() { Code = "342311", Value = "Animator rekreacji i organizacji czasu wolnego" },
                new OccupationCodeItem() { Code = "422701", Value = "Ankieter" },
                new OccupationCodeItem() { Code = "263205", Value = "Antropolog" },
                new OccupationCodeItem() { Code = "522101", Value = "Antykwariusz" },
                new OccupationCodeItem() { Code = "813101", Value = "Aparatowy procesów chemicznych" },
                new OccupationCodeItem() { Code = "816001", Value = "Aparatowy produkcji drożdży" },
                new OccupationCodeItem() { Code = "816002", Value = "Aparatowy produkcji octu" },
                new OccupationCodeItem() { Code = "814101", Value = "Aparatowy produkcji wyrobów maczanych" },
                new OccupationCodeItem() { Code = "263201", Value = "Archeolog" },
                new OccupationCodeItem() { Code = "216101", Value = "Architekt" },
                new OccupationCodeItem() { Code = "216201", Value = "Architekt krajobrazu" },
                new OccupationCodeItem() { Code = "251301", Value = "Architekt stron internetowych" },
                new OccupationCodeItem() { Code = "216102", Value = "Architekt wnętrz" },
                new OccupationCodeItem() { Code = "216202", Value = "Architekt zieleni wewnątrz budynków" },
                new OccupationCodeItem() { Code = "262101", Value = "Archiwista" },
                new OccupationCodeItem() { Code = "441401", Value = "Archiwista dokumentów elektronicznych" },
                new OccupationCodeItem() { Code = "441402", Value = "Archiwista zakładowy" },
                new OccupationCodeItem() { Code = "731801", Value = "Arkadownik" },
                new OccupationCodeItem() { Code = "323013", Value = "Arteterapeuta" },
                new OccupationCodeItem() { Code = "265101", Value = "Artysta fotografik" },
                new OccupationCodeItem() { Code = "265102", Value = "Artysta grafik" },
                new OccupationCodeItem() { Code = "265103", Value = "Artysta malarz" },
                new OccupationCodeItem() { Code = "265104", Value = "Artysta rzeźbiarz" },
                new OccupationCodeItem() { Code = "211101", Value = "Astrofizyk" },
                new OccupationCodeItem() { Code = "516101", Value = "Astrolog" },
                new OccupationCodeItem() { Code = "211102", Value = "Astronom" },
                new OccupationCodeItem() { Code = "431101", Value = "Asystent do spraw księgowości" },
                new OccupationCodeItem() { Code = "331401", Value = "Asystent do spraw statystyki" },
                new OccupationCodeItem() { Code = "441901", Value = "Asystent do spraw wydawniczych" },
                new OccupationCodeItem() { Code = "334302", Value = "Asystent dyrektora" },
                new OccupationCodeItem() { Code = "531203", Value = "Asystent edukacji romskiej" },
                new OccupationCodeItem() { Code = "932919", Value = "Asystent fryzjera" },
                new OccupationCodeItem() { Code = "343902", Value = "Asystent kierownika produkcji filmowej / telewizyjnej S" },
                new OccupationCodeItem() { Code = "531201", Value = "Asystent nauczyciela dziecka cudzoziemca" },
                new OccupationCodeItem() { Code = "531202", Value = "Asystent nauczyciela przedszkola" },
                new OccupationCodeItem() { Code = "531204", Value = "Asystent nauczyciela w szkole" }
            );
        }
    }
}