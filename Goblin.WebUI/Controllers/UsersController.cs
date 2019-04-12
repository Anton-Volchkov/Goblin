using Goblin.Application.Users.Commands.DeleteUser;
using Goblin.Application.Users.Commands.UpdateUser;
using Goblin.Application.Users.Queries.GetAllUsers;
using Goblin.Application.Users.Queries.GetUserByVkId;
using Goblin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Goblin.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UsersViewModel>> Get()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByVkId(int id)
        {
            return await _mediator.Send(new GetUserByVkIdQuery { VkId = id });
        }

        public async Task<ActionResult<bool>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteByVkId(int id)
        {
            return await _mediator.Send(new DeleteUserCommand { VkId = id });
        }
    }
}
