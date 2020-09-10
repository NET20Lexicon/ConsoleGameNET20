using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameNET20
{
    class Orc : Creature
    {
        public Orc(Cell cell) : base(cell, "O ", 125)
        {
            Damage = 25;
            Color = ConsoleColor.Cyan;
        }
    }
}
