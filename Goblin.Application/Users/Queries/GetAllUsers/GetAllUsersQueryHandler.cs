using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UsersViewModel>
    {
        private readonly IMainContext _context;

        public GetAllUsersQueryHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<UsersViewModel> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.AsNoTracking();

            return new UsersViewModel()
            {
                Users = users
            };
        }
    }
}