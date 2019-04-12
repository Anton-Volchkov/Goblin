using MediatR;

namespace Goblin.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int VkId { get; set; }
        public int NarfuGroup { get; set; }
        public bool IsSchedule { get; set; }
        public string City { get; set; }
        public bool IsWeather { get; set; }
        public bool IsErrorDisabled { get; set; }
    }
}