using System.Collections.Generic;
using Goblin.Domain.Entities;

namespace Goblin.Application.Users.Queries.GetWeatherUsers
{
    public class WeatherUsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}