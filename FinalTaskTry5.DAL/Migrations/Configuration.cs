namespace FinalTaskTry5.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalTaskTry5.DAL.EF.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FinalTaskTry5.DAL.EF.ApplicationContext";
        }

        protected override void Seed(FinalTaskTry5.DAL.EF.ApplicationContext context)
        {
        }
    }
}
