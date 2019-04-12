using MediatR;

namespace Goblin.Application.Reminds.Queries.GetRemindsByVkId
{
    public class GetRemindsByVkIdQuery : IRequest<RemindsViewModel>
    {
        public int VkId { get; set; }
    }
}