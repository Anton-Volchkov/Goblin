using System.Threading.Tasks;
using Goblin.Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Goblin.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<bool>> Index(int id)
        {
            return await _mediator.Send(new CreateUserCommand() {VkId = id});
        }
    }
}
