using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTime.AuthSerice.Data.Models;

namespace WorkTime.AuthSerice.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
