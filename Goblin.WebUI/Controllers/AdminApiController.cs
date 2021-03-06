﻿using System.Linq;
using System.Threading.Tasks;
using Goblin.Persistence;
using Microsoft.AspNetCore.Mvc;
using Vk;

namespace Goblin.WebUI.Controllers
{
    [Route("api/admin/[action]")]
    [ValidateAntiForgeryToken]
    public class AdminApiController
    {
        private readonly ApplicationDbContext _db;
        private readonly VkApi _api;

        public AdminApiController(ApplicationDbContext db, VkApi api)
        {
            _db = db;
            _api = api;
        }

        public async Task SendToAll(string msg, string[] attach)
        {
            var gr = _db.GetUsers().Select(x => x.Vk).ToArray();
            await _api.Messages.Send(gr, msg, attach);
        }

        public async Task SendToId(long id, string msg, string[] attachs)
        {
            await _api.Messages.Send(id, msg, attachs);
        }
    }
}