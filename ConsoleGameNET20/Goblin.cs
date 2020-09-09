using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameNET20
{
    class Goblin : Creature
    {
        public Goblin(Cell cell, int maxHealth) : base(cell, "G ", 30)
        {
            Damage = 15;
        }
    }
}
