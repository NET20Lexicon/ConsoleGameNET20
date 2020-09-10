using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;

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
                //case ConsoleKey.P:
                //    PickUp();
                //    break;
                //case ConsoleKey.I:
                //    Inventory();
                //    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            var actionMeny = new Dictionary<ConsoleKey, Action>()
            {
                {ConsoleKey.P, PickUp },
                {ConsoleKey.I, Inventory },
                {ConsoleKey.D, Drop }
            };

            if (actionMeny.ContainsKey(keyPressed))
            {
                var method = actionMeny[keyPressed];
                method?.Invoke();
            }

        }

        private void Drop()
        {
            var item = hero.BackPack.FirstOrDefault();
            if (hero.BackPack.Remove(item))
            {
                // map.GetCell(hero.Cell.Position).Items.Add(item);
                hero.Cell.Items.Add(item);
                UI.AddMessage($"You dropped the {item}");
            }
            else
                UI.AddMessage("Backpack is empty");
        }

        private void Inventory()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Inventory: ");
            for (int i = 0; i < hero.BackPack.Count; i++)
            {
                builder.AppendLine($"{i + 1}: \t{hero.BackPack[i]}");
            }
            UI.AddMessage(builder.ToString());
        }

        private void PickUp()
        {
            if (hero.BackPack.IsFull)
            {
                UI.AddMessage("Backpack is full");
                return;
            }

            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item == null) return;
            if (hero.BackPack.Add(item))
            {
                UI.AddMessage($"Hero picks up {item}");
                items.Remove(item);
            }
        }

        private void Move(Position movement)
        {
            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);

            var opponent = map.CreatureAt(newCell) as Creature;
            if (opponent != null) hero.Attack(opponent);


            if (newCell != null)
            {
                hero.Cell = newCell;
                if (newCell.Items.Any())
                    UI.AddMessage("You see " + string.Join(", ", newCell.Items.Select(i => i.ToString())));

            } 
        }

        private void Drawmap()
        {
            UI.Clear();
            UI.Draw(map);
            UI.PrintStats($"Health: {hero.Health} \nEnemys: {map.Creatures.Count}");
            UI.PrintLog();
        }

        private void Initialize()
        {
            //ToDo: Read from config
            map = new Map(width: 10, height: 10);
            AddCreaturesAndItems();
        }

        private void AddCreaturesAndItems()
        {
            var heroCell = map.GetCell(0, 0);
            hero = new Hero(heroCell);
            map.Creatures.Add(hero);

            var random = new Random();
            map.GetCell(random.Next(0,map.Height), random.Next(0, map.Width)).Items.Add(Item.Coin());
            map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width)).Items.Add(Item.Coin());
            map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width)).Items.Add(Item.Torch());
            map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width)).Items.Add(Item.Torch());

            map.Place(new Orc(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Orc(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Orc(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Goblin(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Goblin(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Goblin(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
        }
    }
}