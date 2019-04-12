using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Goblin.Application.Reminds.Queries.GetRemindsByVkId
{
    public class GetRemindsByVkIdQueryHandler : IRequestHandler<GetRemindsByVkIdQuery, RemindsViewModel>
    {
        private readonly IMainContext _context;

        public GetRemindsByVkIdQueryHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<RemindsViewModel> Handle(GetRemindsByVkIdQuery request, CancellationToken cancellationToken)
        {
            return new RemindsViewModel
            {
                Reminds = _context.Reminds.Where(x => x.UserId == request.VkId)
            };
        }
    }
}