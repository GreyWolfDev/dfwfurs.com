using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class TgUserAuth
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string photo_url { get; set; }
        public string auth_date { get; set; }
        public string hash { get; set; }
    }
}
