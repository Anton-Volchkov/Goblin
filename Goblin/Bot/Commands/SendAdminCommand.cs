﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Goblin.Helpers;

namespace Goblin.Bot.Commands
{
    public class SendAdminCommand : ICommand
    {
        public string Name { get; } = "адм *сообщение*";

        public string Decription { get; } =
            "Отправляет сообщение администратору. Использовать при возникновении ошибок или еще чего-то";

        public string Usage { get; } = "адм ПАМАГИТЕ";
        public List<string> Allias { get; } = new List<string> {"адм"};
        public Category Category { get; } = Category.Common;
        public bool IsAdmin { get; } = false;
        public string Result { get; set; }

        public async Task Execute(string param, int id = 0)
        {
            var username = await VkHelper.GetUserName(id);
            var msg = $"сообщение от @id{id} ({username}):\n\n{param}";
            await VkHelper.SendMessage(VkHelper.DevelopersID, msg);
            Result = "Сообщение успешно отправлено!";
        }

        public bool CanExecute(string param, int id = 0)
        {
            if (string.IsNullOrEmpty(param))
            {
                Result = "Введите сообщение для отправки.";
                return false;
            }

            return true;
        }
    }
}