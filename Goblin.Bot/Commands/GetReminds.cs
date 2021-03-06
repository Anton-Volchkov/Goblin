﻿using System.Linq;
using System.Threading.Tasks;
using Goblin.Bot.Enums;
using Goblin.Bot.Models;
using Goblin.Persistence;
using Microsoft.EntityFrameworkCore;
using Vk.Models.Messages;

namespace Goblin.Bot.Commands
{
    public class GetReminds : ICommand
    {
        public string Name { get; } = "Напоминания";
        public string Decription { get; } = "Получить список с напоминаниями";
        public string Usage { get; } = "Напоминания";
        public string[] Allias { get; } = { "напоминания" };
        public CommandCategory Category { get; } = CommandCategory.Common;
        public bool IsAdmin { get; } = false;

        private readonly ApplicationDbContext _db;

        public GetReminds(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CommandResponse> Execute(Message msg)
        {
            var text = "";
            var ureminds = await _db.Reminds.Where(x => x.VkId == msg.FromId)
                                    .OrderBy(x => x.Date).ToListAsync();
            if(!ureminds.Any())
            {
                text = "Напоминаний нет.";
            }
            else
            {
                var selected = ureminds.Select(rem => $"{rem.Date:dd.MM.yyyy (dddd) HH:mm} - {rem.Text}");
                text = "Список напоминаний: \n" + string.Join("\n", selected);
            }

            return new CommandResponse
            {
                Text = text
            };
        }

        public (bool Success, string Text) CanExecute(Message msg)
        {
            return (true, "");
        }
    }
}