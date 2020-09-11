using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGameNET20
{
    public class ConsoleMap : IMap
    {
        public int Width { get; }
        public int Height { get; }

        private readonly Cell[,] cells;
        public List<Creature> Creatures { get; set; } = new List<Creature>();

        public ConsoleMap(int width, int height)
        {
            Width = width;
            Height = height;

            cells = new Cell[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell(new Position(y, x));
                }
            }
        }

        public IDrawable CreatureAt(Cell cell)
        {
            return Creatures.FirstOrDefault(creature => creature.Cell == cell);
        }

        public Cell GetCell(int y, int x)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return null;
            return cells[y, x];
        }

        public Cell GetCell(Position newPosition)
        {
            return GetCell(newPosition.Y, newPosition.X);
        }

        public void Place(Creature creature)
        {
            if (Creatures.Where(c => c.Cell == creature.Cell).Count() >= 1)
                creature = null;
            else
                Creatures.Add(creature);
        }
    }
}