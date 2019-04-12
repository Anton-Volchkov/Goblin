using System.Threading.Tasks;
using Goblin.Application.Reminds.Commands.CreateRemind;
using Goblin.Application.Reminds.Queries.GetReminds;
using Goblin.Application.Reminds.Queries.GetRemindsByVkId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RemindsViewModel = Goblin.Application.Reminds.Queries.RemindsViewModel;

namespace Goblin.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class RemindsController : Controller
    {
        private readonly IMediator _mediator;

        public RemindsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<RemindsViewModel>> GetAllReminds()
        {
            return await _mediator.Send(new GetRemindsQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RemindsViewModel>> GetByVkId(int id)
        {
            return await _mediator.Send(new GetRemindsByVkIdQuery() { VkId = id });
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Put([FromBody] CreateRemindCommand command)
        {
            return await _mediator.Send(command);
        }
        
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
