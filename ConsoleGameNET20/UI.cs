using LimitedList;
using System;
using System.Linq;

namespace ConsoleGameNET20
{
    internal static class UI
    {
        private static MessageLog<string> messageLog = new MessageLog<string>(6);

        public static void AddMessage(string message) => messageLog.Add(message);

        public static void PrintLog()
        {
            messageLog.ActionAll(m => Console.WriteLine(m));
        }

        internal static ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }

        internal static void Clear()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        internal static void Draw(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);
                    IDrawable drawable = map.CreatureAt(cell) ??  (IDrawable)cell.Items.FirstOrDefault() ??  cell;
                 
                    //if(drawable is null)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.White;
                    //}
                    //else
                    //{
                    //    Console.ForegroundColor = drawable.Color;
                    //}

                    Console.ForegroundColor = drawable?.Color ?? ConsoleColor.White;
                    Console.Write(drawable?.Symbol);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}