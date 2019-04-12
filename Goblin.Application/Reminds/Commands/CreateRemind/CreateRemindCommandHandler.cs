using System.Threading;
using System.Threading.Tasks;
using Goblin.Domain.Entities;
using MediatR;

namespace Goblin.Application.Reminds.Commands.CreateRemind
{
    public class CreateRemindCommandHandler : IRequestHandler<CreateRemindCommand, bool>
    {
        private readonly IMainContext _context;

        public CreateRemindCommandHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateRemindCommand request, CancellationToken cancellationToken)
        {
            await _context.Reminds.AddAsync(new Remind()
            {
                UserId = request.VkId,
                Time = request.Date,
                Text = request.Text
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}