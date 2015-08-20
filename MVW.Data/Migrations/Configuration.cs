namespace MVW.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// first time:enable-migrations �u�ϥΤ@���|����Configuration.cs 
    /// 1.add-migration:�|�����ɮסA����i�H�z�LMigrateDatabaseToLatestVersion �Ӧb����ɴ���s
    /// 2.update-database:�۰ʧ�s��ƮwAutomaticMigrationsEnabled,AutomaticMigrationDataLossAllowed�n�]��true
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
