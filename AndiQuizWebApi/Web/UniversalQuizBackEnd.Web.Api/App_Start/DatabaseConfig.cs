namespace UniversalQuizBackEnd.Web.Api
{
    using UniversalQuizBackEnd.Data;
    using UniversalQuizBackEnd.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversalQuizBackEndDbContext, Configuration>());
        }
    }
}
