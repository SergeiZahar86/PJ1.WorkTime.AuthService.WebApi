using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJ1.AuthService.Data.Models;

namespace PJ1.AuthService.Data.Configuration
{
    /// <summary>
    /// Позволяет  настроить тип сущности
    /// в отдельном классе, а не в режиме онлайн в OnModelCreating (ModelBuilder).
    /// </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        /// <summary>
        /// Настраивает сущность типа AppUser.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}