using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class TgGroup
    {
        public int Id { get; set; }
        /// <summary>
        /// Telegram Id of the group
        /// </summary>
        public long TelegramId { get; set; }
        /// <summary>
        /// Name of the group
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Group description, set by group owner
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Link to join the group, if available
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Admin to contact to join, if no link
        /// </summary>
        public string AdminUserName { get; set; }
        /// <summary>
        /// What category the group is in
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Message displayed when a user joins the group
        /// </summary>
        public string WelcomeMessage { get; set; }
        /// <summary>
        /// Ban users who have a community ban?
        /// </summary>
        public bool EnableCommunityBans { get; set; } = true;
        /// <summary>
        /// Anti-bot captcha on join
        /// </summary>
        public bool EnableCaptcha { get; set; } = true;
        public bool AllowNSFW { get; set; } = true;
        public NSFWAction NSFWAction { get; set; }
        public int MemberCount { get; set; }
    }

    public enum NSFWAction
    {
        Warn,
        Kick,
        Ban
    }
}
