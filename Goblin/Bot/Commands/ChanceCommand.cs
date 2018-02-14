﻿using System.Collections.Generic;

namespace Goblin.Bot.Commands
{
    public class ChanceCommand : ICommand
    {
        public string Name { get; } = "Вероятность *событие*";
        public string Decription { get; } = "Возвращает случайную вероятность события";
        public string Usage { get; } = "Вероятность сегодня будет дождь";
        public List<string> Allias { get; } = new List<string>() {"вероятность"};
        public Category Category { get; } = Category.Common;
        public bool IsAdmin { get; } = false;
        public string Result { get; set; }

        public void Execute(string param, int id = 0)
        {
            if (string.IsNullOrEmpty(param))
            {
                Result = "А вопрос где?";
            }
            else
            {
                Result = $"Вероятность данного события: {GetRandom(0, 100)}%";
            }
        }

        public static int GetRandom(int start, int end)
        {
            return new System.Random(System.DateTime.Now.Millisecond * 7).Next(start, end);
        }
    }
}