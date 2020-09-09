using System;

namespace ConsoleGameNET20
{
    public class Item : IDrawable
    {
        private string name;
        public ConsoleColor Color { get; set; }
        public string Symbol { get; }

        public Item(string symbol, ConsoleColor color, string name)
        {
            Symbol = symbol;
            Color = color;
            this.name = name;
        }

        public override string ToString() => name;

        public static Item Coin() => new Item("c ", ConsoleColor.Yellow, "Coin");
        public static Item Torch() => new Item("t ", ConsoleColor.Blue, "Torch");
     
    }
}