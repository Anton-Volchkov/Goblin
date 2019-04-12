using Goblin.Domain.Entities;
using MediatR;

namespace Goblin.Application.Users.Queries.GetUserByVkId
{
    public class GetUserByVkIdQuery : IRequest<User>
    {
        public int VkId { get; set; }
    }
}