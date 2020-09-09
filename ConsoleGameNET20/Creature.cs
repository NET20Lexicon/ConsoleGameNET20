using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleGameNET20
{
    public abstract class Creature : IDrawable
    {
        private int health;
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
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public string Symbol { get; }
        public Cell Cell { get; set; }
        public int Damage { get; set; } = 10;
        public int MaxHealth { get; private set; }
        public bool IsDead => Health <= 0;

        public Creature(Cell cell, string symbol, int maxHealth)
        {
            Cell = cell;
            Symbol = symbol;
            MaxHealth = maxHealth;
        }
    }
}
