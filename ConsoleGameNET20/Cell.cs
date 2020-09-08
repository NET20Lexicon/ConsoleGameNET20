using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameNET20
{
    public class Cell : IDrawable
    {
        public Position Position { get; set; }
        public List<Item> Items { get; } = new List<Item>();
        public string Symbol => ". ";

        public ConsoleColor Color { get; set; }

        public Cell(Position position)
        {
            Position = position;
            Color = ConsoleColor.Red;
        }
    }
}
