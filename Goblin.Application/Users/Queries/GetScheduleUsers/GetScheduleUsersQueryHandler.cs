using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Users.Queries.GetScheduleUsers
{
    public class GetScheduleUsersQueryHandler : IRequestHandler<GetScheduleUsersQuery, ScheduleUsersViewModel>
    {
        private readonly IMainContext _context;

        public GetScheduleUsersQueryHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<ScheduleUsersViewModel> Handle(GetScheduleUsersQuery request, CancellationToken cancellationToken)
        {
            return new ScheduleUsersViewModel
            {
                Users = _context.Users.AsNoTracking().Where(x => x.IsWeather)
            };
        }
    }
}