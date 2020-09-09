using System;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;

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
                case ConsoleKey.P:
                    PickUp();
                    break; 
                case ConsoleKey.I:
                    Inventory();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        private void Inventory()
        {
            foreach (var item in hero.BackPack)
            {
                Console.WriteLine(item);
            }
        }

        private void PickUp()
        {
            throw new NotImplementedException();
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

            //ToDo random position
            map.GetCell(3, 3).Items.Add(Item.Coin());
            map.GetCell(0, 8).Items.Add(Item.Coin());
            map.GetCell(7, 4).Items.Add(Item.Torch());
            map.GetCell(8, 7).Items.Add(Item.Torch());
        }
    }
}