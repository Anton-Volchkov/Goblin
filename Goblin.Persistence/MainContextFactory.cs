using Goblin.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Persistence
{
    public class MainContextFactory : DesignTimeDbContextFactoryBase<MainContext>
    {
        protected override MainContext CreateNewInstance(DbContextOptions<MainContext> options)
        {
            return new MainContext(options);
        }
    }
}