using MediatR;

namespace Goblin.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int VkId { get; set; }
    }
}