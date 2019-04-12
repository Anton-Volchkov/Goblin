using System.Threading;
using System.Threading.Tasks;
using Goblin.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Users.Queries.GetUserByVkId
{
    public class GetUserByVkIdQueryHandler : IRequestHandler<GetUserByVkIdQuery, User>
    {
        private readonly IMainContext _context;

        public GetUserByVkIdQueryHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByVkIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.VkId == request.VkId,
                                                          cancellationToken);

            if(user is null)
            {
                return null;

                //TODO THROW
            }

            return user;
        }
    }
}