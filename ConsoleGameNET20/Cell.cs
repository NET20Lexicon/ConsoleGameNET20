using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameNET20
{
    public class Cell
    {
        public List<Item> Items { get; } = new List<Item>();
        public string Symbol => ". ";

        public Cell()
        {

        }
    }
}
