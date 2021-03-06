﻿using System.Threading.Tasks;
using Goblin.Bot.Enums;
using Goblin.Bot.Models;
using Goblin.Persistence;
using Microsoft.EntityFrameworkCore;
using Vk.Models.Messages;

namespace Goblin.Bot.Commands
{
    public class MuteErrors : ICommand
    {
        public string Name { get; } = "Мут";
        public string Decription { get; } = "Выключить ошибки при написании неправильной команды";
        public string Usage { get; } = "Мут";
        public string[] Allias { get; } = { "мут" };
        public CommandCategory Category { get; } = CommandCategory.Common;
        public bool IsAdmin { get; } = false;

        private readonly ApplicationDbContext _db;

        public MuteErrors(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CommandResponse> Execute(Message msg)
        {
            var user = await _db.BotUsers.FirstOrDefaultAsync(x => x.Vk == msg.FromId);

            user.IsErrorsDisabled = !user.IsErrorsDisabled;
            await _db.SaveChangesAsync();

            return new CommandResponse
            {
                Text = "Ошибочки " + (user.IsErrorsDisabled ? "выключены" : "включены")
            };
        }

        public (bool Success, string Text) CanExecute(Message msg)
        {
            return (true, "");
        }
    }
}