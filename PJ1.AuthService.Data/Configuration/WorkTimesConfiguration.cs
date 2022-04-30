using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJ1.AuthService.Data.Models;

namespace PJ1.AuthService.Data.Configuration
{
    /// <summary>
    /// Позволяет  настроить тип сущности
    /// в отдельном классе, а не в режиме онлайн в OnModelCreating (ModelBuilder).
    /// </summary>
    public class WorkTimesConfiguration : IEntityTypeConfiguration<WorkedTimes>
    {
        /// <summary>
        /// Настраивает сущность типа WorkedTimes.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(
            Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WorkedTimes> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}