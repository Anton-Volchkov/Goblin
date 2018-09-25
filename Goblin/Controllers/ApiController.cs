﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Goblin.Bot;
using Goblin.Helpers;
using Goblin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VkNet.Model.Keyboard;

namespace Goblin.Controllers
{
    public class ApiController : Controller
    {
        public async Task<string> Handler([FromBody] dynamic body)
        {
            var eventType = body["type"].ToString();
            int userID;
            string userName;
            switch (eventType)
            {
                case "confirmation":
                    return VkHelper.ConfirmationToken;

                case "message_new":
                    userID = int.Parse(body["object"]["from_id"].ToString());
                    int convID = int.Parse(body["object"]["peer_id"].ToString());
                    var msg = body["object"]["text"].ToString();
                    if (userID != convID)
                    {
                        var b = Regex.Match(msg, @"\[club146048760\|.*\] (.*)").Groups[1].Value;
                        if (b != "")
                            msg = b;
                    }

                    if (!DbHelper.Db.Users.Any(x => x.Vk == userID))
                    {
                        await DbHelper.Db.Users.AddAsync(new User {Vk = userID});
                        await DbHelper.Db.SaveChangesAsync();
                    }

                    (string Message, MessageKeyboard Keyboard) forSend = await CommandsList.ExecuteCommand(msg, userID);
                    await VkHelper.SendMessage(convID, forSend.Message, forSend.Keyboard);
                    break;

                case "group_join":
                    userID = int.Parse(body["object"]["user_id"].ToString());
                    userName = await VkHelper.GetUserName(userID);
                    await VkHelper.SendMessage(VkHelper.DevelopersID, $"@id{userID} ({userName}) подписался!");
                    break;

                case "group_leave":
                case "message_deny":
                    userID = int.Parse(body["object"]["user_id"].ToString());
                    if (await DbHelper.Db.Users.AnyAsync(x => x.Vk == userID))
                    {
                        DbHelper.Db.Users.Remove(DbHelper.Db.Users.First(x => x.Vk == userID));
                        await DbHelper.Db.SaveChangesAsync();
                    }

                    userName = await VkHelper.GetUserName(userID);
                    await VkHelper.SendMessage(VkHelper.DevelopersID, $"@id{userID} ({userName}) отписался!");
                    break;
            }

            return "ok";
        }

        public async Task SendMessage(string msg)
        {
            if (!ModelState.IsValid) return;
            await VkHelper.SendMessage(DbHelper.GetUsers().Select(x => x.Vk).ToList(), msg);
        }

        public async Task SendWeather()
        {
            await Task.Factory.StartNew(async () =>
            {
                var grouped = DbHelper.GetWeatherUsers().GroupBy(x => x.City);
                foreach (var group in grouped)
                {
                    var ids = group.Select(x => x.Vk).ToList();
                    await VkHelper.SendMessage(ids, await WeatherHelper.GetWeather(group.Key));
                    await Task.Delay(1500);
                }
            });
        }

        public async Task SendSchedule()
        {
            await Task.Factory.StartNew(async () =>
            {
                var grouped = DbHelper.GetScheduleUsers().GroupBy(x => x.Group);
                var i = 0; //TODO: remove
                foreach (var group in grouped)
                {
                    var ids = group.Select(x => x.Vk).ToList();
                    var schedule = await ScheduleHelper.GetScheduleAtDate(DateTime.Today, group.Key);
                    await VkHelper.SendMessage(ids, schedule);
                    await Task.Delay(1500);
                    i++;
                }

                await VkHelper.SendMessage(VkHelper.DevelopersID, $"result: {i}, expected 8");
            });
        }

        public async Task SendToPesi()
        {
            var konfa = 2000000003;
            var schedule = await ScheduleHelper.GetScheduleAtDate(DateTime.Now, 351617);
            var weather = await WeatherHelper.GetWeather("Архангельск");

            await VkHelper.SendMessage(konfa, weather);
            await VkHelper.SendMessage(konfa, schedule);
        }
    }
}