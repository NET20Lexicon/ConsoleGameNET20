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
                GetInput();
                //Get command
                //execute
                Drawmap();
                //Drawmap
                //enemy actions
                //Drawmap

              //  Console.ReadKey();
            } while (gameInProgrees);
        }

        private void GetInput()
        {
            var keyPressed = UI.GetKey();

            switch (keyPressed)
            {
                case ConsoleKey.LeftArrow:
                    Move(Direction.West);
                    break;
                case ConsoleKey.RightArrow:
                    Move(Direction.East);
                    break;
                case ConsoleKey.UpArrow:
                    Move(Direction.North);
                    break;
                case ConsoleKey.DownArrow:
                    Move(Direction.South);
                    break;
                default:
                    break;
            }

        }

        private void Move(Position movement)
        {

            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);
            if (newCell != null) hero.Cell = newCell;
        }

        private void Drawmap()
        {
            UI.Clear();
            UI.Draw(map);
            
        }

        private void Initialize()
        {
            //ToDo: Read from config
            map = new Map(width: 10, height: 10);
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);
        }
    }
}