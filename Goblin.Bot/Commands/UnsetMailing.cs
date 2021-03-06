﻿using System.Threading.Tasks;
using Goblin.Bot.Enums;
using Goblin.Bot.Models;
using Goblin.Persistence;
using Microsoft.EntityFrameworkCore;
using Vk.Models.Messages;

namespace Goblin.Bot.Commands
{
    public class UnsetMailing : ICommand
    {
        public string Name { get; } = "Отписка *расписание ИЛИ погода*";
        public string Decription { get; } = "Отписка от рассылки расписания или погоды";
        public string Usage { get; } = "Отписка погода";
        public string[] Allias { get; } = { "отписка" };
        public CommandCategory Category { get; } = CommandCategory.Common;
        public bool IsAdmin { get; } = false;

        private readonly ApplicationDbContext _db;

        public UnsetMailing(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CommandResponse> Execute(Message msg)
        {
            var canExecute = CanExecute(msg);
            if(!canExecute.Success)
            {
                return new CommandResponse
                {
                    Text = canExecute.Text
                };
            }

            var param = msg.GetParamsAsArray()[0].ToLower();
            var text = "";
            if(param == "погода")
            {
                var user = await _db.BotUsers.FirstAsync(x => x.Vk == msg.FromId);
                user.Weather = false;
                text = "Ты отписался от рассылки погоды :с";
            }
            else if(param == "расписание")
            {
                var user = await _db.BotUsers.FirstAsync(x => x.Vk == msg.FromId);
                user.Schedule = false;
                text = "Ты отписался от рассылки расписания :с";
            }
            else
            {
                text = $"Ошибка. Можно отписаться от рассылки погоды или расписания (выбрано - {param})";
            }

            if(_db.ChangeTracker.HasChanges())
            {
                await _db.SaveChangesAsync();
            }

            return new CommandResponse
            {
                Text = text
            };
        }

        public (bool Success, string Text) CanExecute(Message msg)
        {
            if(string.IsNullOrEmpty(msg.GetParams()))
            {
                return (false, "А от чего отписаться? Укажи 'погода' либо 'расписание'");
            }

            return (true, "");
        }
    }
}