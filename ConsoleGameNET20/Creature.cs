using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleGameNET20
{
    public abstract class Creature : IDrawable
    {
        private int health;
        private string name => this.GetType().Name;

        private ConsoleColor color;
        public ConsoleColor Color 
        {
            get
            {
                return IsDead ? ConsoleColor.Gray : color;
            }
            set
            {
                color = value;
            }
        } 
        public int Health 
        {
            get { return health < 0 ? 0 : health; } 
            set 
            {
                if(value >= MaxHealth)
                {
                    health = MaxHealth;
                }
                else
                {
                    health = value;
                }
            }
        }
        public string Symbol { get; }
        public Cell Cell { get; set; }
        public int Damage { get; set; } = 10;
        public int MaxHealth { get; private set; }
        public bool IsDead => Health <= 0;
        public Action<string> AddMessage { get; set; }

        public Creature(Cell cell, string symbol, int maxHealth)
        {
            Cell = cell;
            Symbol = symbol;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        internal void Attack(Creature target)
        {
            if (target.IsDead) return;

            var thisName = this.name;
            var targetName = target.name;

            target.Health -= Damage;
            AddMessage?.Invoke($"The {thisName} attacks the {targetName} for {Damage}");

            if (target.IsDead)
            {
                AddMessage($"The {targetName} is dead!");
                return;
            }

            Health -= target.Damage;
            AddMessage?.Invoke($"The {targetName} attacks the {thisName} for {Damage}");

            if (IsDead)
            {
                AddMessage?.Invoke($"The {thisName} is dead!");
                return;
            }
            
        }
    }
}
