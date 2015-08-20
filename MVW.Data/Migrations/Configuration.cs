namespace MVW.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// first time:enable-migrations 只使用一次會產生Configuration.cs 
    /// 1.add-migration:會產生檔案，之後可以透過MigrateDatabaseToLatestVersion 來在執行時期更新
    /// 2.update-database:自動更新資料庫AutomaticMigrationsEnabled,AutomaticMigrationDataLossAllowed要設為true
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<MVW.Data.MVWDataBase>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;//old
            AutomaticMigrationsEnabled = true;//New
            AutomaticMigrationDataLossAllowed = true;//New
            ContextKey = "MVW.Data.MVWDataBase";
        }

        protected override void Seed(MVW.Data.MVWDataBase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
