using System.Threading;
using System.Threading.Tasks;
using Goblin.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IMainContext _context;

        public CreateUserCommandHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.VkId == request.VkId, cancellationToken);
            if(user != null) //TODO
            {
                return false;
            }

            await _context.Users.AddAsync(new User
            {
                VkId = request.VkId
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}