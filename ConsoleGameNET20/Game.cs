using System;
using System.ComponentModel.Design;
using System.Data;

namespace ConsoleGameNET20
{
    internal class Game
    {
        private Map map;
        private Hero hero;

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {
            bool gameInProgrees = true;
            do
            {
                Drawmap();
                //Drawmap
                //Get command
                //execute
                //Drawmap
                //enemy actions
                //Drawmap

                Console.ReadKey();
            } while (gameInProgrees);
        }

        private void Drawmap()
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Cell cell = map.GetCell(y, x);
                    Console.Write(cell.Symbol);
                }
                Console.WriteLine();
            }
        }

        private void Initialize()
        {
            //ToDo: Read from config
            map = new Map(width: 10,height: 10);
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
        }
    }
}