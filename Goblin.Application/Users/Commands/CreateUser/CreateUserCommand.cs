using MediatR;

namespace Goblin.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public int VkId { get; set; }
    }
}