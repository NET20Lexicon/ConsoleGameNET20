using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameNET20
{
    class Orc : Creature
    {
        public Orc(Cell cell, int maxHealth) : base(cell, "O ", maxHealth)
        {
            Damage = 25;
            Color = ConsoleColor.Cyan;
        }
    }
}
