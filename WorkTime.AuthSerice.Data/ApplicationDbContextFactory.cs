using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WorkTime.AuthSerice.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        // public ApplicationDbContext CreateDbContext(string[] args)
        // {
        //     var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //     optionsBuilder.UseSqlServer("Data Source=host.docker.internal,1433;Initial Catalog=Holi;User Id=sa;Password=2712iwitn;Persist Security Info=True");
        //
        //     return new ApplicationDbContext(optionsBuilder.Options);
        // }
        
        
        
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MY_Project_11_04_22;Username=postgres;Password=2712");

            return new ApplicationDbContext(optionsBuilder.Options);
        }

    }
}
