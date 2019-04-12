using System.Collections.Generic;
using Goblin.Domain.Entities;

namespace Goblin.Application.Users.Queries.GetAllUsers
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}