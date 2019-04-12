﻿using System.Threading.Tasks;
using Goblin.Application.Users.Commands.CreateUser;
using Goblin.Application.Users.Commands.DeleteUser;
using Goblin.Application.Users.Commands.UpdateUser;
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
            return await _mediator.Send(new CreateUserCommand() { VkId = id });
        }

        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _mediator.Send(new DeleteUserCommand() { VkId = id });
        }

        public async Task<ActionResult<bool>> Update(int id, string city)
        {
            return await _mediator.Send(new UpdateUserCommand() { VkId = id, City = city});
        }
    }
}