using System;
using System.Collections.Generic;

namespace ConsoleGameNET20
{
    internal class Map
    {
        public int Width { get; }
        public int Height { get; }

        private readonly Cell[,] cells;
        public List<Creature> Creatures { get; set; } = new List<Creature>();

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            cells = new Cell[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell(y,x);
                }
            }
        }

        internal Cell GetCell(int y, int x)
        {
            //ToDo: Refactor
            try
            {
                return cells[y, x];
            }
            catch (Exception)
            {
                return null;                 
            }
        }
    }
}