using System;

namespace ConsoleGameNET20
{
    internal class Hero : Creature
    {
        public Hero(Cell cell) : base(cell, "H ") 
        {
            Color = ConsoleColor.Yellow;
        }
    }
}