using LimitedList;
using System;
using Microsoft.Extensions.Configuration;

namespace ConsoleGameNET20
{
    class Program
    {
        static void Main(string[] args)
        {
            var startUp = new StartUp();
            startUp.SetUp();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();

        }
    }
}
