using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WorkTime.AuthSerice.Data.Configuration;
using WorkTime.AuthSerice.Data.Models;

namespace WorkTime.AuthSerice.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser, AppRole, int>
    //public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<WorkedTimes> WorkedTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));

            //builder.Entity<AppRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<AppRole>(entity => entity.ToTable(name: "Roles"));

            builder.Entity<IdentityUserRole<int>>(entity => entity.ToTable(name: "UserRoles"));

            builder.Entity<IdentityUserClaim<int>>(entity => entity.ToTable(name: "UserClaim"));

            builder.Entity<IdentityUserLogin<int>>(entity => entity.ToTable("UserLogins"));

            builder.Entity<IdentityUserToken<int>>(entity => entity.ToTable("UserTokens"));

            builder.Entity<IdentityRoleClaim<int>>(entity => entity.ToTable("RoleClaims"));

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new WorkTimesConfiguration());

        }

    }
}
