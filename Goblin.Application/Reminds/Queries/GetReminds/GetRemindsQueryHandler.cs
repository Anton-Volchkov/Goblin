using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Application.Reminds.Queries.GetReminds
{
    public class GetRemindsQueryHandler : IRequestHandler<GetRemindsQuery, RemindsViewModel>
    {
        private readonly IMainContext _context;

        public GetRemindsQueryHandler(IMainContext context)
        {
            _context = context;
        }

        public async Task<RemindsViewModel> Handle(GetRemindsQuery request, CancellationToken cancellationToken)
        {
            return new RemindsViewModel()
            {
                Reminds = _context.Reminds.AsNoTracking()
            };
        }
    }
}