using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Bot.Models
{
    public class Captcha
    {
        public int Hash { get; }
        public string FilePath { get; }

        public Captcha(int Hash, string FilePath)
        {
            this.Hash = Hash;
            this.FilePath = FilePath;
        }
    }

}
