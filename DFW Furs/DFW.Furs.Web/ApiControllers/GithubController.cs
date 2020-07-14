using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Bot;
using DFW.Furs.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFW.Furs.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        [HttpPost]
        public ActionResult Push([FromBody] GitHubPush p)
        {
            Bot.Bot.Client.SendTextMessageAsync(-226056121, $"New commit:\n{p.pusher.name}\nCommits:\n" +
                $"{p.commits.Aggregate("", (c, v) => $"{c}\n{v.message} - {v.author.username}")}\n\nSent to Azure for build");

            return Ok();
        }
    }
}
