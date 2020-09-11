using LimitedList;
using System;
using Microsoft.Extensions.Configuration;

namespace ConsoleGameNET20
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Environment.CurrentDirectory)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

            var ui = config.GetSection("consolegame:ui").Value;
            var x = config.GetSection("consolegame:mapsettings:x").Value;
            var mapsettings = config.GetSection("consolegame:mapsettings").GetChildren();

            Game game = new Game(config);
            game.Run();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();

        }
    }
}
