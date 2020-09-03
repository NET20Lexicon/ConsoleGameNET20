using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameNET20
{
    public class Cell : IDrawable
    {
        public int X { get;  }
        public int Y { get;  }
        public List<Item> Items { get; } = new List<Item>();
        public string Symbol => ". ";

        public ConsoleColor Color { get; set; }

        public Cell(int y, int x)
        {
            X = x;
            Y = y;
            Color = ConsoleColor.Red;
        }
    }
}
