using System;

namespace Goblin.Domain.Entities
{
    public class Remind
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
    }
}