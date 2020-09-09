using LimitedList;
using System;

namespace ConsoleGameNET20
{
    internal class Hero : Creature
    {
        public LimitedList<Item> BackPack { get; set; }
        public Hero(Cell cell) : base(cell, "H ", 100) 
        {
            Color = ConsoleColor.Yellow;
            BackPack = new LimitedList<Item>(3);
        }
    }
}