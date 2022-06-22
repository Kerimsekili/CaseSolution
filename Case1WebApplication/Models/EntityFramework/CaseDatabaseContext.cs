using Microsoft.EntityFrameworkCore;


namespace Case1WebApplication.Models.EntityFramework
{
    //Context : Db tablolarını proje classlarını bağlama
    public class CaseDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CaseDatabase;Trusted_Connection=true");

        }

        public DbSet<Student> Students { get; set; }
    }
}
