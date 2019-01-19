﻿using System.Threading.Tasks;
using Goblin.Helpers;
using Microsoft.EntityFrameworkCore;
using Vk.Models.Messages;

namespace Goblin.Bot.Commands
{
    public class SetMailing : ICommand
    {
        public string Name { get; } = "Подписка *расписание/погода*";
        public string Decription { get; } = "Подписка на рассылку расписания/погоды (ЧТО-ТО ОДНО ЗА РАЗ)";
        public string Usage { get; } = "Подписка расписание";
        public string[] Allias { get; } = {"подписка"};
        public Category Category { get; } = Category.Common;
        public bool IsAdmin { get; } = false;

        public async Task<CommandResponse> Execute(Message msg)
        {
            var canExecute = CanExecute(msg);
            if (!canExecute.Success)
            {
                return new CommandResponse
                {
                    Text = canExecute.Text
                };
            }

            var param = msg.GetParamsAsArray()[0].ToLower();
            var text = "";
            if (param == "погода")
            {
                var user = await DbHelper.Db.Users.FirstAsync(x => x.Vk == msg.FromId);
                user.Weather = true;
                text = "Ты успешно подписался на рассылку погоды!";
            }
            else if (param == "расписание")
            {
                var user = await DbHelper.Db.Users.FirstAsync(x => x.Vk == msg.FromId);
                user.Schedule = true;
                text = "Ты успешно подписался на рассылку расписания!";
            }
            else
            {
                text = $"Ошибка. Можно подписаться на рассылку погоды или расписания (выбрано - {param})";
            }

            if (DbHelper.Db.ChangeTracker.HasChanges())
                await DbHelper.Db.SaveChangesAsync();

            return new CommandResponse
            {
                Text = text
            };
        }

        public (bool Success, string Text) CanExecute(Message msg)
        {
            if (string.IsNullOrEmpty(msg.GetParams()))
            {
                return (false, "А на что подписаться? Укажи 'погода' либо 'расписание'");
            }

            return (true, "");
        }
    }
}