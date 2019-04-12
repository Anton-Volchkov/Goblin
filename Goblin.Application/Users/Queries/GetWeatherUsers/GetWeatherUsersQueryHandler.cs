using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Users.Queries.GetWeatherUsers
{
    public class GetWeatherUsersQueryHandler : IRequestHandler<GetWeatherUsersQuery, WeatherUsersViewModel>
    {
        private readonly IMainContext _context;

        public GetWeatherUsersQueryHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<WeatherUsersViewModel> Handle(GetWeatherUsersQuery request, CancellationToken cancellationToken)
        {
            return new WeatherUsersViewModel
            {
                Users = _context.Users.AsNoTracking().Where(x => x.IsWeather)
            };
        }
    }
}