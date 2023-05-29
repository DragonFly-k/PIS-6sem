using System.Data.Entity;
using Interface;
using PhoneDictionary;

namespace DbLib
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base(
            "Data Source=DESKTOP-M01CN9D,33678;Initial Catalog=pis2;User=sa;Password=1111;TrustServerCertificate=True;Integrated Security=False;")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Phone> Phones { get; set; }
    }
}
