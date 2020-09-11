﻿using System.Collections.Generic;

namespace ConsoleGameNET20
{
    public interface IMap
    {
        List<Creature> Creatures { get; set; }
        int Height { get; }
        int Width { get; }

        IDrawable CreatureAt(Cell cell);
        Cell GetCell(int y, int x);
        Cell GetCell(Position newPosition);
        void Place(Creature creature);
    }
}