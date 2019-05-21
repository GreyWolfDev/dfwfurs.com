using DFW.Furs.Api;
using System;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var posts = Telegram.ParseChannel("DFWEvents").Result;
            Console.Read();
        }
    }
}
