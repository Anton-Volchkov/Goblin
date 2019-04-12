using System;
using MediatR;

namespace Goblin.Application.Reminds.Commands.CreateRemind
{
    public class CreateRemindCommand : IRequest<bool>
    {
        public int VkId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}