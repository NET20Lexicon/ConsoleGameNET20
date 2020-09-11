using LimitedList;
using System;
using System.Linq;

namespace ConsoleGameNET20
{
    public class ConsoleUI : IUI
    {
        private MessageLog<string> messageLog = new MessageLog<string>(6);

        public void AddMessage(string message) => messageLog.Add(message);

        public void PrintLog()
        {
            messageLog.ActionAll(Print);
        }

        private void Print(string message)
        {
            Console.WriteLine(message + new string(' ', Console.WindowWidth - message.Length));
        }

        public ConsoleKey GetKey()
        {
            return Console.ReadKey(intercept: true).Key;
        }

        public void Clear()
        {
            //Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Draw(IMap map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);
                    IDrawable drawable = map.CreatureAt(cell) ?? (IDrawable)cell.Items.FirstOrDefault() ?? cell;

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

        public void PrintStats(string stats)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stats);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}