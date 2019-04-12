using System.Collections.Generic;
using Goblin.Domain.Entities;

namespace Goblin.Application.Reminds.Queries
{
    public class RemindsViewModel
    {
        public IEnumerable<Remind> Reminds { get; set; }
    }
}