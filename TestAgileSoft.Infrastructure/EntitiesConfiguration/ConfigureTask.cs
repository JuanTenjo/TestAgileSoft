using Microsoft.EntityFrameworkCore;
using TestAgileSoft.Domain.Entities;

namespace TestAgileSoft.Infrastructure.EntitiesConfiguration
{
    internal static class ConfigureTask
    {
        internal static void ConfigureModelTask(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>();
        }
    }
}
