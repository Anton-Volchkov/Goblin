using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IMainContext _context;

        public UpdateUserCommandHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.VkId == request.VkId,
                                                                cancellationToken);
            if(user is null)
            {
                return false; //TODO
            }

            user.City = request.City;
            user.IsWeather = request.IsWeather;
            user.NarfuGroup = request.NarfuGroup;
            user.IsSchedule = request.IsSchedule;
            user.IsErrorDisabled = request.IsErrorDisabled;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}