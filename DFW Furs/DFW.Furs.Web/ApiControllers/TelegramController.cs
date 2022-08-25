using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Api;
using DFW.Furs.Api.Interfaces;
using DFW.Furs.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFW.Furs.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TelegramController : ControllerBase
    {
        private readonly Api.Telegram Telegram;
        public TelegramController()
        {
            Telegram = new Api.Telegram();
        }
        [HttpGet]
        public async Task<IEnumerable<TgChannelPost>> Get(string channel = "DFWEvents", int total = 3)
        {
            //TODO: Add error handling
            //TODO: Move this to greywolfdev.net
            return await Telegram.GetItems(channel, total);
        }
    }
}