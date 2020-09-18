using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Data.Context
{
    public class CMTestsContext : CMContext
    {
        public CMTestsContext(DbContextOptions<CMContext> options) : base(options)
        {
        }

        public static CMTestsContext SqlLiteInMemoryContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CMContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new CMTestsContext(optionsBuilder);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }
    }

}
