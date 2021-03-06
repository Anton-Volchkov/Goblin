﻿using Vk.Models.Keyboard;

namespace Goblin.Bot.Models
{
    public class CommandResponse
    {
        public string Text { get; set; }
        public Keyboard Keyboard { get; set; }
        public string[] Attachments { get; set; }
    }
}