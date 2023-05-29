using System.Data.Entity.Migrations;
using MVC2.App_Data;

namespace MVC2.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}