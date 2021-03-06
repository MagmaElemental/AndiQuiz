﻿namespace AndiQuiz.Server.Api
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AndiQuizDbContext, Configuration>());
            AndiQuizDbContext.Create().Database.Initialize(true);
        }
    }
}
