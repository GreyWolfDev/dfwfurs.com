using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Bot;
using DFW.Furs.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DFW.Furs.Database;

namespace DFW.Furs.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class GithubController : ControllerBase
    {
        private readonly DFWDbContext _context;

        public GithubController(DFWDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Push([FromBody] GitHubPush p)
        {
            Bot.Bot.Client.SendTextMessageAsync(-226056121, $"New push from {p.pusher.name}\n\nCommits:\n" +
                $"{p.commits.Aggregate("", (c, v) => $"{c}\n<a href=\"{v.url}\">{v.id.Substring(0,7)}</a>: {v.message}")}\n\nSent to Azure for build", Telegram.Bot.Types.Enums.ParseMode.Html);

            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return "Ok";
        }
    }
}
