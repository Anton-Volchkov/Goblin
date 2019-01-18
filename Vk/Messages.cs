﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vk.Models.Keyboard;

namespace Vk
{
    public class Messages
    {
        public async Task Send(long id, string text, string[] attachs = null, Keyboard kb = null)
        {
            await Send(new[] { id }, text, attachs, kb);
        }

        public async Task Send(long[] ids, string text, string[] attachs = null, Keyboard kb = null)
        {
            if (string.IsNullOrEmpty(text) || ids.Length == 0)
            {
                return;
            }

            var values = new Dictionary<string, string>()
            {
                ["message"] = text,
                ["random_id"] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(), //TODO
                ["peer_ids"] = string.Join(',', ids)
            };

            if (!(attachs is null)) // если есть аттачи
            {
                values.Add("attachment", string.Join(",", attachs));
            }

            if (!(kb is null)) // если есть клавиатура
            {
                values.Add("keyboard", kb.ToString());
            }

            await VkApi.SendRequest("messages.send", values); //TODO to bool?
        }
    }
}