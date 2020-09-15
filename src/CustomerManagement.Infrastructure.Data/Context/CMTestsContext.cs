using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Data.Context
{
    public class CMTestsContext : CMContext
    {
        private DbContextOptions<CMTestsContext> optionsBuilder;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            GetConnection(optionsBuilder);
        }

        protected override void GetConnection(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=:memory:");
        }

        public CMTestsContext(DbContextOptions<CMTestsContext> optionsBuilder)
        {
            this.optionsBuilder = optionsBuilder;
        }

        public static CMTestsContext SqlLiteInMemoryContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CMTestsContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new CMTestsContext(optionsBuilder);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

    }
}
