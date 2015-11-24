using CAR.DAL.Models;
using System.Data.Entity;

namespace CAR.DAL
{
    public class CarContext : DbContext
    {
        public CarContext() : base("CarContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarContext>());
        }

        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
