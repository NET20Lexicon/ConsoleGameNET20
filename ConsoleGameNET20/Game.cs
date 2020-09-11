using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleGameNET20
{
    internal class Game
    {
        private IUI ui;
        private IMap map;
        private Hero hero;
        private bool gameInProgrees = true;
        private IConfiguration config;

        public Game(IConfiguration config)
        {
            this.config = config;
        }

        internal void Run()
        {
            Initialize();
            Play();
        }

        private void Play()
        {
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
            var keyPressed = ui.GetKey();

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
                ui.AddMessage($"You dropped the {item}");
            }
            else
                ui.AddMessage("Backpack is empty");
        }

        private void Inventory()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Inventory: ");
            for (int i = 0; i < hero.BackPack.Count; i++)
            {
                builder.AppendLine($"{i + 1}: \t{hero.BackPack[i]}");
            }
            ui.AddMessage(builder.ToString());
        }

        private void PickUp()
        {
            if (hero.BackPack.IsFull)
            {
                ui.AddMessage("Backpack is full");
                return;
            }

            var items = hero.Cell.Items;
            var item = items.FirstOrDefault();
            if (item == null) return;

            if(item is IUsable usable)
            {
                usable.Use(hero);
                hero.Cell.Items.Remove(item);
                ui.AddMessage($"You use the {item}");
                return;
            }

            if (hero.BackPack.Add(item))
            {
                ui.AddMessage($"Hero picks up {item}");
                items.Remove(item);
            }
        }

        private void Move(Position movement)
        {
            Position newPosition = hero.Cell.Position + movement;
            Cell newCell = map.GetCell(newPosition);

            var opponent = map.CreatureAt(newCell) as Creature;
            if (opponent != null) hero.Attack(opponent);

            gameInProgrees = !hero.IsDead;

            if (newCell != null)
            {
                hero.Cell = newCell;
                if (newCell.Items.Any())
                    ui.AddMessage("You see " + string.Join(", ", newCell.Items.Select(i => i.ToString())));

            } 
        }

        private void Drawmap()
        {
            ui.Clear();
            ui.Draw(map);
            ui.PrintStats($"Health: {hero.Health} \nEnemys: {map.Creatures.Where(c => !c.IsDead).Count() -1}");
            ui.PrintLog();
        }

        private void Initialize()
        {
            ui = new ConsoleUI();

            int width = int.Parse(config.GetSection("consolegame:mapsettings:x").Value);
           
            var mapSett = config.GetSection("consolegame:mapsettings");

            int.TryParse(mapSett["y"], out int height);

            map = new ConsoleMap(width, height);
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
            map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width)).Items.Add(Item.Coin());
            map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width)).Items.Add(Item.Torch());
            map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width)).Items.Add(Portion.HealthPortion());
            map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width)).Items.Add(Portion.HealthPortion());

            map.Place(new Orc(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Orc(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Orc(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Goblin(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Goblin(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));
            map.Place(new Goblin(map.GetCell(random.Next(0, map.Height), random.Next(0, map.Width))));

            map.Creatures.ForEach(c => c.AddMessage = ui.AddMessage);
            map.Creatures.ForEach(c => c.AddMessage += (s) => Debug.WriteLine(s));
        }
    }
}