using DFW.Furs.Api;
using System;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var posts = Telegram.ParseChannel("DFWEvents").Result;
            posts.Reverse();
            foreach (var p in posts)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{p.MessageAuthor}: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{p.Text}\r\n");
            }
            Console.Read();
        }
    }
}
