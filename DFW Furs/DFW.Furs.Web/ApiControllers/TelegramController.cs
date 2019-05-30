using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Api;
using DFW.Furs.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFW.Furs.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        [HttpGet]
        public async Task<List<TgChannelPost>> Get(string channel = "DFWEvents", int total = 3)
        {
            //TODO: Add error handling
            return await Telegram.ParseChannel(channel, total);
        }
    }
}