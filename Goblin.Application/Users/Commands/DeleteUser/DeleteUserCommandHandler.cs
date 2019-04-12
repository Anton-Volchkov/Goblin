using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IMainContext _context;

        public DeleteUserCommandHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.VkId == request.VkId,
                                                                cancellationToken);
            if(user is null)
            {
                return false; //TODO: throw?
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}