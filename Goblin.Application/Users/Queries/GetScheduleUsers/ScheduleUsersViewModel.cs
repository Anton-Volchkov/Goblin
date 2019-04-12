using System.Collections.Generic;
using Goblin.Domain.Entities;

namespace Goblin.Application.Users.Queries.GetScheduleUsers
{
    public class ScheduleUsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}