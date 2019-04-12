using System.Threading;
using System.Threading.Tasks;
using Goblin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application
{
    public interface IMainContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Remind> Reminds { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}